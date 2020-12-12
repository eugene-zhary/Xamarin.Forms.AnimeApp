using System;
using System.Collections.Generic;
using System.Text;

namespace Anime.Views
{
    public interface IBindablePage
    {
        /// <summary>
        /// Gets or sets the binding context.
        /// </summary>
        object BindingContext { get; set; }
    }
}
