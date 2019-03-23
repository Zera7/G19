using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using G19.Source.Interface;
using SFML.System;

namespace G19.Source
{
    public abstract class ParentLayer : Layer, IParentLayer, ISubShadersDrawable
    {
        public Dictionary<string, ExtendedLinkedList<Layer>> SubLayers { get; set; } = new Dictionary<string, ExtendedLinkedList<Layer>>();

        public RenderTexture FrontShaderTexture { get; set; }
        public RenderTexture BackShaderTexture { get; set; }

        public override void Update(Time time)
        {
            var ListsForUpdate = new List<Tuple<string, ExtendedLinkedList<Layer>>>(SubLayers.Count + 1);

            foreach (var layerList in SubLayers)
            {
                var isNeedToClearList = layerList.Value.IsNeedToClearRemovedElements;
                var bufferLayersList = isNeedToClearList ? new ExtendedLinkedList<Layer>() : null;

                foreach (var layer in layerList.Value)
                {
                    if (!layer.IsRemoved)
                    {
                        layer.Update(time);
                        if (layer.IsRemoved)
                            layerList.Value.RemovedElementsCount += 1;
                        else if (isNeedToClearList)
                            bufferLayersList.AddLast(layer);
                    }
                }

                if (isNeedToClearList)
                    ListsForUpdate.Add(Tuple.Create(layerList.Key, bufferLayersList));
            }

            foreach (var item in ListsForUpdate)
                SubLayers[item.Item1] = item.Item2;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            if (IsRemoved)
                return;

            DrawLayer(states);
            DrawSubShaders(states);
            DrawSubLayers(states);
            BackShaderTexture.Display();
            target.Draw(new Sprite(BackShaderTexture.Texture));
        }

        public void AddShaderToRenderTexture(RenderStates states)
        {
            states.Shader.SetParameter("texture", BackShaderTexture.Texture);
            // draw "back" into "front"
            FrontShaderTexture.Clear();
            FrontShaderTexture.Draw(new Sprite(BackShaderTexture.Texture), states);
            FrontShaderTexture.Display();

            // swap front and back buffers
            RenderTexture temp = FrontShaderTexture;
            FrontShaderTexture = BackShaderTexture;
            BackShaderTexture = temp;
        }

        private void DrawLayer(RenderStates states)
        {
            var newStates = new RenderStates(states)
            {
                Shader = GetInnerShader()
            };

            BackShaderTexture.Clear();
            BackShaderTexture.Draw(Background, newStates);
        }

        public void DrawSubShaders(RenderStates states)
        {
            foreach (var list in SubLayers)
            {
                if (list.Value.Count - list.Value.RemovedElementsCount == 0)
                    continue;

                var shader = list.Value.First.Value.GetExternalShader();
                var index = 0;

                if (shader != null)
                {
                    foreach (var layer in list.Value)
                    {
                        if (layer.IsRemoved)
                            continue;

                        layer.SetExternalShaderParameters(index);
                        index += 1;
                    }
                    list.Value.First.Value.SetExternalShaderGeneralParameters();

                    shader.SetParameter("arrayCount", index);
                    var newStates = new RenderStates(states)
                    {
                        Shader = shader
                    };
                    AddShaderToRenderTexture(newStates);
                }
            }
        }

        private void DrawSubLayers(RenderStates states)
        {
            foreach (var list in SubLayers)
                foreach (var layer in list.Value)
                    if (!layer.IsRemoved)
                        BackShaderTexture.Draw(layer, states);
        }
    }
}