﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Iceland_Moss.Extensions
{
    public static class ViewExtension
    {
        /// <summary>
        /// Gets the page to which an element belongs
        /// </summary>
        /// <returns>The page.</returns>
        /// <param name="element">Element.</param>
        public static Page GetParentPage(this VisualElement element)
        {
            if (element != null)
            {
                var parent = element.Parent;
                while (parent != null)
                {
                    if (parent is Page)
                    {
                        return parent as Page;
                    }
                    parent = parent.Parent;
                }
            }
            return null;
        }
    }
}
