using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public interface IPlayerClothPicker
    {
        public KeyCode GetPickButton();

        public void SetClothHandler(IClothHandler clothHandler);

    }
}