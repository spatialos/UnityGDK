using System.Linq;
using UnityEngine.UIElements;

namespace Improbable.Gdk.Debug.WorkerInspector.Codegen
{
    public abstract class SchemaTypeVisualElement<T> : VisualElement, IConcealable<T>
    {
        public string Label
        {
            get => labelElement.text;
            set => labelElement.text = value;
        }

        public int FieldCount => Container.childCount;

        protected readonly VisualElement Container;
        private readonly Label labelElement;

        protected SchemaTypeVisualElement(string label)
        {
            AddToClassList("user-defined-type-container");

            labelElement = new Label(label);
            Add(labelElement);

            Container = new VisualElement();
            Container.AddToClassList("user-defined-type-container-data");
            Add(Container);
        }

        public abstract void SetVisibility(T data, bool hideIfEmpty);

        public abstract void Update(T data);
    }
}
