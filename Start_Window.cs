using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI___Obstacle_Board
{
	public partial class Start_Window : Form
	{
		/* Constant Value = Sqaure Size */
		public const int Square_Size = 50;


		/* ---------------------------------- Initialized Window -------------------------------- */

		[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
		private static extern IntPtr CreateRoundRectRgn
		(
			int nLeftRect,			/* X - Coordinate of Upper - Left Corner  */
			int nTopRect,			/* Y - Coordinate of Upper - Left Corner  */
			int nRightRect,			/* X - Coordinate of Lower - Right Corner */
			int nBottomRect,		/* Y - Coordinate of Lower - Right Corner */
			int nWidthEllipse,		/* Height of Ellipse */
			int nHeightEllipse		/* Width of Ellipse */
		);


		/**
		 * Initialized The Component.
		 **/
		public Start_Window()
		{
			InitializeComponent();
		}


		/**
		 * This Function Loading The Start Window.
		 **/
		private void Start_Window_Load(object sender, EventArgs e)
		{
			/* Load The Combo Box With Value's */
			for(int Index = 6; Index <= 10; Index++)
			{
				Combo_Box_Details.Items.Add(Index.ToString() + " x " + Index.ToString());
			}

			/* Color's */
			Label_One.ForeColor = ColorTranslator.FromHtml("#2a3551");
			Label_One.BackColor = ColorTranslator.FromHtml("#c5b597");
			Label_Value.ForeColor = ColorTranslator.FromHtml("#5b71ab");
			Combo_Box_Details.BackColor = ColorTranslator.FromHtml("#c5b597");
			Button_Start_Game.BackColor = ColorTranslator.FromHtml("#f96363");
			Panel_Right_Start_Window.BackColor = ColorTranslator.FromHtml("#eae5db");

			/* Combo Box */
			Combo_Box_Details.DropDownStyle = ComboBoxStyle.DropDownList;
			Label_Error.Visible = false;

			/* Rounded Border's */
			this.FormBorderStyle = FormBorderStyle.None;
			Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
		}


		/* ---------------------------------- Button -------------------------------------------- */


		/**
		 * Function For The Button Of Starting Game.
		 **/
		private async void Button_Start_Game_Click(object sender, EventArgs e)
		{
			/* Take The Text Of Rows */
			string Row = Combo_Box_Details.Text.ToString();
			if(Row.Contains("6")) { Row = "6"; }
			else if (Row.Contains("7")) { Row = "7"; }
			else if (Row.Contains("8")) { Row = "8"; }
			else if (Row.Contains("9")) { Row = "9"; }
			else if (Row.Contains("10")) { Row = "10"; }

			/* Take The Text Of Cols */
			string Col = Combo_Box_Details.Text.ToString();
			if (Col.Contains("6")) { Col = "6"; }
			else if (Col.Contains("7")) { Col = "7"; }
			else if (Col.Contains("8")) { Col = "8"; }
			else if (Col.Contains("9")) { Col = "9"; }
			else if (Col.Contains("10")) { Col = "10"; }

			/* Check Error's Case's */
			if (Check_Errors_Case(Row, Col) == true)
			{
				return;
			}

			/* The Details Correct */
			Label_Error.ForeColor = ColorTranslator.FromHtml("#5b71ab");
			Label_Error.Text = "We Can Start The Game !";
			Label_Error.Visible = true;

			/* Delay For - 2 Second */
			await Task.Delay(2000);

			/* Hide This GUI */
			this.Hide();

			/* Create New Form */
			Obstacle_Board Obstacle_Board_Object = new Obstacle_Board(Row,Col, Square_Size);

			/* Show The Form */
			Obstacle_Board_Object.ShowDialog();	
		}


		/**
		 * This Function Check The Error Case.
		 **/
		public bool Check_Errors_Case(string Row , string Col)
		{
			/* Row / Col Empty , Or Contains ===> N */
			if (Row.CompareTo("") == 0)		
			{
				Label_Error.ForeColor = ColorTranslator.FromHtml("#f96363");
				Label_Error.Text = "Details Not Correct , Choose Your Size Again !";
				Label_Error.Visible = true;
				return true;
			}

			/* We Dont Have Error Case */
			return false;
		}
	}
}
