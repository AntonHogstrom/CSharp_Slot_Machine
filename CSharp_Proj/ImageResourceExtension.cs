using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSharp_Proj
{
	[ContentProperty (nameof(Source))]
	 
	public class ImageResourceExtension : IMarkupExtension
	{
		public string Source { get; set; }

		public object ProvideValue(IServiceProvider serviceProvider)
        {
			if (Source == null)
			{
				Console.WriteLine("Image = Null");
				return null;
			}

			ImageSource imageSource = ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
			return imageSource;
		}
	}
}

