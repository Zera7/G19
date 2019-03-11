using G19.Source.Interface;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace G19.Source
{
    public abstract class Layer : Transformable, ILayer
    {
        public Dictionary<string, ExtendedLinkedList<ILayer>> SubLayers { get; set; } = new Dictionary<string, ExtendedLinkedList<ILayer>>();
        public Shader InnerShader { get; set; }
        public Shader ExternalShader { get; set; }
        public bool IsRemoved { get; set; }

        public abstract Drawable Background { get; set; }

        public virtual void Update(Time time)
        {
            var ListsForUpdate = new List<Tuple<string, ExtendedLinkedList<ILayer>>>(SubLayers.Count + 1);

            foreach (var layerList in SubLayers)
            {
                var isNeedToClearList = layerList.Value.IsNeedToClearRemovedElements;
                var bufferLayersList = isNeedToClearList ? new ExtendedLinkedList<ILayer>() : null;

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
            {
                SubLayers[item.Item1] = item.Item2;
                SubLayers[item.Item1].RemovedElementsCount = 0;
            }
        }

        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            if (IsRemoved)
                return;

            var OriginalStates = new RenderStates(states);

            if (Background != null)
                target.Draw(Background);

            DrawSubShaders(target, ref OriginalStates);

            foreach (var list in SubLayers)
                foreach (var layer in list.Value)
                    if (!layer.IsRemoved)
                        target.Draw(layer, OriginalStates);

            if (InnerShader != null)
            {
                states.Shader = InnerShader;
                target.Draw(Background, states);
            }
        }

        public virtual void DrawSubShaders(RenderTarget target, ref RenderStates states)
        {
        }

        public virtual void HideLayer(Time time)
        {
        }

        public virtual void ShowLayer(Time time)
        {
        }
    }
}