using System;
using System.Collections.Generic;
using System.Linq;
using Improbable.Gdk.Core;
using Unity.Entities;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Improbable.Gdk.Debug.WorkerInspector
{
    internal class EntityList : VisualElement
    {
        public delegate void EntitySelected(EntityData entityId);

        public EntitySelected OnEntitySelected;

        private readonly EntityListData entities = new EntityListData();
        private readonly ListView listView;

        private EntitySystem entitySystem;
        private int lastViewVersion;
        private EntityData? selectedEntity;

        public EntityList()
        {
            const string uxmlPath = "Packages/io.improbable.gdk.debug/WorkerInspector/Templates/EntityList.uxml";
            var template = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(uxmlPath);
            template.CloneTree(this);

            listView = this.Q<ListView>();
            listView.makeItem = () => new Label();
            listView.bindItem = BindItem;
            listView.onSelectionChange += OnSelectionChanged;
            listView.itemsSource = entities.FilteredData;

            var searchField = this.Q<ToolbarSearchField>();
            searchField.RegisterCallback<ChangeEvent<string>>(OnSearchFieldChanged);
        }

        public void Update()
        {
            if (entitySystem == null)
            {
                listView.Refresh();
                return;
            }

            if (entitySystem.ViewVersion == lastViewVersion)
            {
                return;
            }

            entities.RefreshData();
            listView.Refresh();

            // Attempt to continue focusing the previously selected value.
            if (selectedEntity != null)
            {
                var index = entities.FilteredData.IndexOf(selectedEntity.Value);

                if (index != -1)
                {
                    listView.selectedIndex = index;
                }
            }

            lastViewVersion = entitySystem.ViewVersion;
        }

        public void SetWorld(World world)
        {
            entitySystem = world?.GetExistingSystem<EntitySystem>();
            lastViewVersion = -1;
            selectedEntity = null;

            entities.SetNewWorld(world);
        }

        private void BindItem(VisualElement element, int index)
        {
            var entity = entities.FilteredData[index];
            var label = (Label) element;
            label.text = entity.ToString();
        }

        private void OnSelectionChanged(IEnumerable<object> selections)
        {
            if (selections.Count() != 1)
            {
                throw new InvalidOperationException("Unexpectedly selected more than one entity.");
            }

            if (!(selections.First() is EntityData entityData))
            {
                throw new InvalidOperationException($"Unexpected type for selection: {selections.First().GetType()}");
            }

            if (!selectedEntity.HasValue || selectedEntity.Value != entityData)
            {
                OnEntitySelected?.Invoke(entityData);
                selectedEntity = entityData;
            }
        }

        private void OnSearchFieldChanged(ChangeEvent<string> changeEvent)
        {
            var searchValue = changeEvent.newValue.Trim();
            entities.ApplySearch(EntitySearchParameters.FromSearchString(searchValue));
            listView.Refresh();
        }

        public new class UxmlFactory : UxmlFactory<EntityList>
        {
        }
    }
}
