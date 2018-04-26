using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace AniWar
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public Tile[,] tile_arr = new Tile[8, 15];
        List<Button> col_row = new List<Button>();
       // public Player player1 = new Player("P1", "패트", 100, 100, 30, 50, tile_arr[0, 0]);
        //public Player player2 = new Player("P2", "김두한", 144, 44, 44, 54, tile_arr[1, 1]);


        public MainWindow()
        {
            InitializeComponent();

            mapLoad();
            servantLoad();
            //white_tile(player1);
            System.Diagnostics.Debug.WriteLine("tile_arr[3,3] = " + tile_arr[3,3].col +" , "+ tile_arr[3, 3].row);
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            

        }
        public class Tile
        {
            public Button Tile_button;
            public int col;
            public int row;
            bool is_white;
            bool is_can;
        }

        public void servantLoad()
        {
            BitmapImage servant_bitmap = new BitmapImage();
            servant_bitmap.BeginInit();
            servant_bitmap.UriSource = new Uri(@"\image\15fbd9380e71211a5.png", UriKind.Relative);
            servant_bitmap.EndInit();

            Image sevant_Image = new Image
            {
                Source = servant_bitmap,
                Margin = tile_arr[0, 0].Tile_button.Margin
            };
            System.Diagnostics.Debug.WriteLine("servant_bitmap.UriSource : " + servant_bitmap.UriSource);


            grid1.Children.Add(sevant_Image);
            image_test.Source = servant_bitmap;

        }
        public void mapLoad()
        {
            int x = 200;
            int y = 100;
            //Button[,] tile_arr = new Button[8, 15];


            for (int col = 0; col < 8; col++)
            {

                for (int row = 0; row < 15; row++)
                {
                    tile_arr[col, row].Tile_button = new Button
                    {
                        Height = 48,
                        Width = 54,
                        Margin = new Thickness(x, y, 0, 0),
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Content = "o"
                    };
                    tile_arr[col, row].col = col;
                    tile_arr[col, row].col = row;

                    grid1.Children.Add(tile_arr[col, row].Tile_button);

                    x += 59;
                }
                x = 200;
                y += 53;
            }

        }

        public void white_tile(Tile tile ,int movePower) // 갈수있는 타일을 표시해줌 
        {
            int row = tile.row;
            int col = tile.col;
            int col_max = col + movePower;
            int col_min = col - movePower;

            int row_max = row + movePower;
            int row_min = row - movePower;

        

            for (int n = col_min; n <= col_max; n++)
            {
                col_row.Add(tile_arr[n, row].Tile_button);
                
               // List.(tile_arr[n, row]);
               // tile_arr[n, row].
            }
            System.Diagnostics.Debug.WriteLine("@@@@@@@@@@@@@@@@col_row : " + col_row);
        }

        

    }







}

/*
 *  <!-- 버튼 시작점 >>Margin="200,100,0,0"<<  margin은 59씩 15번 증가 후 Margin="200,153,0,0" 53씩 y축이 한번 증가후 다시 15번씩 증가 -->
        <Button Content="Button" HorizontalAlignment="Left" Height="48" Margin="200,100,0,0" VerticalAlignment="Top" Width="54"/>
        */