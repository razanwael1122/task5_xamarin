using Plugin.Media;
using Plugin.Media.Abstractions;
using Syncfusion.SfImageEditor.XForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace task5
{
    public partial class MainPage : ContentPage
    {
        public Command DrawCompleted { get; set; }

        public MainPage()
        {
            
            InitializeComponent();

            {

                
         ImgEditor.Source = ImageSource.FromResource(":/storage/emulated/0/Android/data/com.companyname.task5/files/Pictures/Pictures");

            }


        }
         async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var crossmedia = CrossMedia.Current;
            if (crossmedia.IsCameraAvailable && crossmedia.IsTakePhotoSupported)
            {
                
                var file = await crossmedia.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {                                 
                    Name = DateTime.Now.Millisecond.ToString() + ".jgp",
                    Directory = "Pictures"

                });
               // await DisplayAlert("Alert!",file.Path, "ok");
                ImgEditor.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();


                    return stream;
                });

            }
            else
            {
                await DisplayAlert("Alert!", "Camera is not available", "ok");
            }

         }
        




        /*async void Button1_Clicked(System.Object sender, System.EventArgs e)
        {
        var result = await MediaPicker.CapturePhotoAsync();
        var stream = await result.OpenReadAsync();
        ImgEditor.Source = ImageSource.FromStream(() => stream);

        }*/



    }
}





