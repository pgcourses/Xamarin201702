using Day1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Day1.View
{
    public class TaskListView : ContentPage
    {
        public TaskListView(List<TaskViewModel> vm)
        {
            var dataTemplate = new DataTemplate(() => {

                var lblTitle = new Label { FontSize=30 };
                lblTitle.SetBinding(Label.TextProperty, "Title");

                var lblPriority = new Label { FontSize=18 };
                lblPriority.SetBinding(Label.TextProperty, "PriorityText");

                var cell = new ViewCell {
                    View = new StackLayout {
                        Padding = 5
                        ,Children =
                        {
                            lblTitle
                            ,new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal
                                ,Children =
                                {
                                    new Label { Text="Prioritás:", VerticalTextAlignment=TextAlignment.Center }
                                    ,lblPriority
                                }
                            }
                        }
                    }
                };

                return cell;
            });

            Content = new ListView {
                HasUnevenRows = true,
                ItemsSource = vm,
                ItemTemplate = dataTemplate
            };
        }
    }
}
