using System;
using CodeBase.Runtime.Infrastructure.EntityView;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Armaments.Behaviours
{
  public class AuraSizeListener : EntityDependant
  {
    [SerializeField] private Transform _container;

    private float _radiusPrevious;

    private void Update()
    {
      if (Math.Abs(Entity.Radius - _radiusPrevious) < Mathf.Epsilon)
        return;

      SetAuraScale();
    }

    private void SetAuraScale()
    {
      float scale = Entity.Radius * 2;
      _container.localScale = new Vector3(scale, scale, scale);
      _radiusPrevious = Entity.Radius;
    }
  }
}