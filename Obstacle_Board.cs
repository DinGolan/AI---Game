using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI___Obstacle_Board
{
	public partial class Obstacle_Board : Form
	{
		/* Boolean */
		public bool Cant_Get_To_Last_Point = false;
		public bool Change_Location = false;

		/* String */
		public string Row;
		public string Col;

		/* Integer */
		public int Sqaure_Size;

		/* List */
		public List<Node> List_Of_Nodes = new List<Node>();
		public List<Node> Final_Path = new List<Node>();


		/* ---------------------------------- Initialized Board --------------------------------- */


		/**
		 * Constructor.
		 **/
		public Obstacle_Board(string Row, string Col, int Sqaure_Size)
		{
			InitializeComponent();
			this.Row = Row;
			this.Col = Col;
			this.Sqaure_Size = Sqaure_Size;
		}


		/**
		 * This Function Loading The Obstacale Board.
		 **/
		private void Obstacle_Board_Load(object sender, EventArgs e)
		{
			/* Disabled - Show Steps Button */
			Button_Show_Steps.Enabled = false;

			/* Color's */
			Label_Head_Line.ForeColor = ColorTranslator.FromHtml("#2a3551");
			Label_Head_Line.BackColor = ColorTranslator.FromHtml("#c5b597");
			Button_Show_Board.BackColor = ColorTranslator.FromHtml("#f96363");
			Button_Show_Steps.BackColor = ColorTranslator.FromHtml("#5b71ab");
			Button_Close_Game.BackColor = ColorTranslator.FromHtml("#2a3551");
			this.BackColor = ColorTranslator.FromHtml("#eae5db");
		}


		/* ---------------------------------- Create Board -------------------------------------- */


		/**
		 * This Function Create The Board , After We Load The Form.
		 **/
		public void Create_Board(string Row, string Col)
		{
			/* Coordinates In The Board */
			int X_Cordinate = 0;
			int Y_Cordinate = 0;

			/* Square Length , And Size Of Form , Panel */
			int Square_Length = 50;
			int Size_Of_Rows = Square_Length * Convert.ToInt32(Row);
			int Size_Of_Cols = Square_Length * Convert.ToInt32(Col);

			/* Size Of ===> Form */
			this.Size = new Size(Size_Of_Rows + 300, Size_Of_Cols + 200);

			/* Organized The Location Of The ===> Form */
			this.StartPosition = FormStartPosition.Manual;
			this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
			this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;

			/* Change The Size Of ---> Panel */
			Panel_Obstacle_Board.Size = new Size(Size_Of_Rows, Size_Of_Cols);

			/* Organized The Location Of The ===> Panel */
			Panel_Obstacle_Board.Location = new Point((this.ClientSize.Width / 2 - Panel_Obstacle_Board.Size.Width / 2) + 30,
													  (this.ClientSize.Height / 2 - Panel_Obstacle_Board.Size.Height / 2) + 15);
			Panel_Obstacle_Board.Anchor = AnchorStyles.None;

			/* Change The Location Of The Text Box's / Lable's Only One Time */
			if (Change_Location == false)
			{
				Label_Black.Location = new Point(Panel_Obstacle_Board.Location.X + Size_Of_Cols + 35, Label_Black.Location.Y);
				Label_Red.Location = new Point(Panel_Obstacle_Board.Location.X + Size_Of_Cols + 35, Label_Red.Location.Y);
				Label_Green.Location = new Point(Panel_Obstacle_Board.Location.X + Size_Of_Cols + 35, Label_Green.Location.Y);
				Label_Gold.Location = new Point(Panel_Obstacle_Board.Location.X + Size_Of_Cols + 35, Label_Gold.Location.Y);
				Label_Yellow.Location = new Point(Panel_Obstacle_Board.Location.X + Size_Of_Cols + 35, Label_Yellow.Location.Y);
				Text_Black.Location = new Point(Panel_Obstacle_Board.Location.X + Size_Of_Cols + 35, Text_Black.Location.Y);
				Text_Red.Location = new Point(Panel_Obstacle_Board.Location.X + Size_Of_Cols + 35, Text_Red.Location.Y);
				Text_Green.Location = new Point(Panel_Obstacle_Board.Location.X + Size_Of_Cols + 35, Text_Green.Location.Y);
				Text_Gold.Location = new Point(Panel_Obstacle_Board.Location.X + Size_Of_Cols + 35, Text_Gold.Location.Y);
				Text_Yellow.Location = new Point(Panel_Obstacle_Board.Location.X + Size_Of_Cols + 35, Text_Yellow.Location.Y);

				if (Convert.ToInt32(Row) == 6) { Label_Head_Line.Location = new Point(Label_Head_Line.Location.X + 15, Label_Head_Line.Location.Y); }
				else if (Convert.ToInt32(Row) == 7) { Label_Head_Line.Location = new Point(Label_Head_Line.Location.X + 40, Label_Head_Line.Location.Y); }
				else if (Convert.ToInt32(Row) == 8) { Label_Head_Line.Location = new Point(Label_Head_Line.Location.X + 70, Label_Head_Line.Location.Y); }
				else if (Convert.ToInt32(Row) == 9) { Label_Head_Line.Location = new Point(Label_Head_Line.Location.X + 100, Label_Head_Line.Location.Y); }
				else if (Convert.ToInt32(Row) == 10) { Label_Head_Line.Location = new Point(Label_Head_Line.Location.X + 135, Label_Head_Line.Location.Y); }

				Change_Location = true;
			}

			/* Create The Graphics Of The Board */
			Graphics Board_Graphic = Panel_Obstacle_Board.CreateGraphics();
			Pen Pen_Graphics = new Pen(Color.White, 10);
			SolidBrush Solid_Brush_Red = new SolidBrush(Color.Red);
			SolidBrush Solid_Brush_Green = new SolidBrush(Color.Green);
			SolidBrush Solid_Brush_Gray = new SolidBrush(Color.Gray);
			SolidBrush Solid_Brush_Black = new SolidBrush(Color.Black);

			/* The Length That We Need To Run On The ===> Loop */
			int Length_Of_Loop = (Size_Of_Rows * Size_Of_Cols) / (Convert.ToInt32((Math.Pow(Square_Length, 2))));

			/* Randoms Numbers */
			int Min = 2;
			int Max = Convert.ToInt32(Row) + 1;
			List<int> Random_Numbers_Array = new List<int>();
			Random Random_Number = new Random();
			int Gold_Number; 

			do
			{
				/* Default Value , If We Will Randomize Again */
				Random_Numbers_Array.Clear();
				Min = 2;
				Max = Convert.ToInt32(Row) + 1;

				while (Random_Numbers_Array.Count < Convert.ToInt32(Row))
				{
					/* Adding Random Number */
					Random_Numbers_Array.Add(Random_Number.Next(Min, Max));		
					Min = Max;

					/* The Last Iteration */
					if (Random_Numbers_Array.Count + 1 == Convert.ToInt32(Row))
					{
						Max += Convert.ToInt32(Row) - 1;
					}
					else
					{
						Max += Convert.ToInt32(Row);
					}
				}
			} while (Check_The_Random_Array_Numbers(Row, Random_Numbers_Array) == false);

			/* Randomize - Gold Number */
			do
			{
				Min = 2;
				Gold_Number = Random_Number.Next(Min, (Convert.ToInt32(Row) * Convert.ToInt32(Col)));
			} while (Random_Numbers_Array.Contains(Gold_Number) == true);

			/* Build The Board */
			for (int Index = 0; Index < Length_Of_Loop; Index++)
			{
				/* Make The Square */
				Point[] Points = new Point[4];
				Points[0] = new Point(X_Cordinate, Y_Cordinate);
				Points[1] = new Point(X_Cordinate, Y_Cordinate + Square_Length);
				Points[2] = new Point(X_Cordinate + Square_Length, Y_Cordinate + Square_Length);
				Points[3] = new Point(X_Cordinate + Square_Length, Y_Cordinate);
				Board_Graphic.DrawLines(Pen_Graphics, Points);
				Board_Graphic.DrawPolygon(Pen_Graphics, Points);

				/* Convert The Points To Node Object */
				List_Of_Nodes.Add(new Node(0, Points));
				List_Of_Nodes[List_Of_Nodes.Count - 1].Set_Number_Of_Node(Index + 1);

				if (Index == 0)
				{
					Board_Graphic.FillPolygon(Solid_Brush_Green, Points);

					/* The Last One In Each Iteration */
					List_Of_Nodes[List_Of_Nodes.Count - 1].Set_Color("Green");
				}
				else if (Index == Length_Of_Loop - 1)
				{
					Board_Graphic.FillPolygon(Solid_Brush_Red, Points);

					/* The Last One In Each Iteration */
					List_Of_Nodes[List_Of_Nodes.Count - 1].Set_Color("Red");
				}
				else if (Random_Numbers_Array.Contains(Index + 1) == true)
				{
					Board_Graphic.FillPolygon(Solid_Brush_Black, Points);

					/* The Last One In Each Iteration */
					List_Of_Nodes[List_Of_Nodes.Count - 1].Set_Value(-1);
					List_Of_Nodes[List_Of_Nodes.Count - 1].Set_Color("Black");
				}
				else if((Index + 1) == Gold_Number)
				{
					Board_Graphic.FillPolygon(new SolidBrush(Color.Gold) , Points);

					/* The Last One In Each Iteration */
					List_Of_Nodes[List_Of_Nodes.Count - 1].Set_Color("Gold");
				}
				else
				{
					Board_Graphic.FillPolygon(Solid_Brush_Gray, Points);

					/* The Last One In Each Iteration */
					List_Of_Nodes[List_Of_Nodes.Count - 1].Set_Color("Gray");
				}

				X_Cordinate += Square_Length;
				if (X_Cordinate == Size_Of_Rows)
				{
					X_Cordinate = 0;
					Y_Cordinate += Square_Length;
				}
			}

			/** ----- Explain -----
			 * A. True = We Dont Have A Path.
			 * B. False = We Have A Path.
			 **/
			if (Check_If_We_Dont_Have_Path(List_Of_Nodes) == true)
			{
				/* We Cant Show The Board */
				Button_Show_Steps.Enabled = false;

				/* Show Error Message To The User */
				MessageBox.Show("We Don't Have Path , Because The Neighbors Of The Last Point Is Obstacles !",
								"Please , Try To Show Another Board",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
			}
		}


		/**
		 * This Function , Check If We Cant Find Path.
		 **/
		public bool Check_If_We_Dont_Have_Path(List<Node> List_Of_Node)
		{
			/* The Neighbors Of The Last Node */
			if ((List_Of_Node[List_Of_Node.Count - 2].Get_Color().CompareTo("Black") == 0) &&
			   (List_Of_Node[List_Of_Node.Count - (Convert.ToInt32(Row) + 1)].Get_Color().CompareTo("Black") == 0))
			{
				/* We Dont Have A Path , So We Return True */
				return true;
			}

			/* The Neighbors Of The First Node */
			else if ((List_Of_Node[1].Get_Color().CompareTo("Black") == 0) &&
					(List_Of_Node[Convert.ToInt32(Row)].Get_Color().CompareTo("Black") == 0))
			{
				/* We Dont Have A Path , So We Return True */
				return true;
			}

			/* We Have A Path , So We Return False */
			return false;
		}


		/**
		 * Check The Random Numbers , Because We Want To Insure That In Every Row We Will Have Only One Obstacle.
		 **/
		public bool Check_The_Random_Array_Numbers(string Row, List<int> Random_Numbers_Array)
		{
			for (int Index = 0; Index < Random_Numbers_Array.Count; Index++)
			{
				if ((Random_Numbers_Array[Index] <= Index * Convert.ToInt32(Row)) ||
				   (Random_Numbers_Array[Index] > (Index + 1) * Convert.ToInt32(Row)))
				{
					/* The Number Not In The Range That We Expect */
					return false;
				}
			}

			/* All The Obstacle Locate In Great Location */
			return true;
		}


		/* ---------------------------------- Getters & Setters --------------------------------- */


		/**
		 * Get - Row.
		 **/
		public string Get_Row()
		{
			return this.Row;
		}


		/**
		 * Set - Row.
		 **/
		public void Set_Row(string Row)
		{
			this.Row = Row;
		}


		/**
		 * Get - Col.
		 **/
		public string Get_Col()
		{
			return this.Col;
		}


		/**
		 * Set - Col.
		 **/
		public void Set_Col(string Col)
		{
			this.Col = Col;
		}


		/**
		 * Get - Sqaure Size.
		 **/
		public int Get_Sqaure_Size()
		{
			return this.Sqaure_Size;
		}


		/**
		 * Set - Sqaure Size.
		 **/
		public void Set_Sqaure_Size(int Sqaure_Size)
		{
			this.Sqaure_Size = Sqaure_Size;
		}


		/**
		 * Get - Final Path.
		 **/
		public List<Node> Get_Final_Path()
		{
			return this.Final_Path;
		}


		/**
		 * Set - Final Path.
		 **/
		public void Set_Final_Path(List<Node> Final_Path)
		{
			this.Final_Path = Final_Path;
		}


		/* ---------------------------------- Button's ------------------------------------------ */


		/**
		 * With This Function I Show The Board.
		 **/
		private void Button_Show_Board_Click(object sender, EventArgs e)
		{
			/* Default Configuration , If We Use Again */
			List_Of_Nodes.Clear();
			Final_Path.Clear();
			Button_Show_Steps.Enabled = true;
			Cant_Get_To_Last_Point = false;

			/* Creating The Board */
			Create_Board(this.Row, this.Col);

			/* Change The Text */
			Button Local_Button = (Button)sender;
			Local_Button.Text = "Show Another Board";
			Local_Button.Font = new Font("Century", 8, FontStyle.Bold);
		}


		/**
		 * In This Function We Make The AI ===> A Star.
		 * In Each Step We Calculate , What Is The Bost Move That We Can Make.
		 **/
		private void Button_Show_Steps_Click(object sender, EventArgs e)
		{
			/* Boolean For - Exception Case */
			bool We_Have_Obstacle_In_Final_Path = false;

			/* Boolean For Gold - Square */
			bool Gold_Square_Exist = false;

			Button Local_Button = (Button)sender;
			Local_Button.Enabled = false;

			/* Calling To The A* Function */
			A_Star(List_Of_Nodes);

			if (Cant_Get_To_Last_Point == false)
			{
				/* Check If We Have Black Node */
				foreach (Node Specific_Node in Final_Path)
				{
					if (Specific_Node.Get_Color().CompareTo("Black") == 0)
					{
						We_Have_Obstacle_In_Final_Path = true;

						/* Show Error Message To The User */
						MessageBox.Show("In The Final Path , We Have Obstacle Square's - It's Mean Error In The Code !",
										"Please , Try To Show Another Board",
										MessageBoxButtons.OK,
										MessageBoxIcon.Error);

						/* Give To The User The Possibility To Show The Steps Again */
						Button_Show_Steps.Enabled = true;
						break;
					}

					if(Specific_Node.Get_Color().CompareTo("Gold") == 0)
					{
						Gold_Square_Exist = true;
					}
				}

				if (We_Have_Obstacle_In_Final_Path == false)
				{
					/* Draw The Path From The Start Until The End Of The Board */
					Graphics Board_Graphic = Panel_Obstacle_Board.CreateGraphics();
					Pen Pen_Graphics = new Pen(Color.White, 10);
					SolidBrush Solid_Brush_Red = new SolidBrush(Color.Red);
					SolidBrush Solid_Brush_Green = new SolidBrush(Color.Green);
					SolidBrush Solid_Brush_Gray = new SolidBrush(Color.Gray);
					SolidBrush Solid_Brush_Black = new SolidBrush(Color.Black);
					SolidBrush Solid_Brush_Yellow = new SolidBrush(Color.Yellow);

					foreach (Node Specific_Node in List_Of_Nodes)
					{
						if (Final_Path.Contains(Specific_Node) == true)
						{
							Board_Graphic.DrawLines(Pen_Graphics, Specific_Node.Get_Points());
							Board_Graphic.DrawPolygon(Pen_Graphics, Specific_Node.Get_Points());
							if ((Specific_Node.Get_Color().CompareTo("Gray") == 0) || (Specific_Node.Get_Color().CompareTo("Gold") == 0))
							{
								Board_Graphic.FillPolygon(Solid_Brush_Yellow, Specific_Node.Get_Points());
							}
							else if (Specific_Node.Get_Color().CompareTo("Green") == 0)
							{
								Board_Graphic.FillPolygon(Solid_Brush_Green, Specific_Node.Get_Points());
							}
							else if (Specific_Node.Get_Color().CompareTo("Red") == 0)
							{
								Board_Graphic.FillPolygon(Solid_Brush_Red, Specific_Node.Get_Points());
							}
						}

						else
						{
							Board_Graphic.DrawLines(Pen_Graphics, Specific_Node.Get_Points());
							Board_Graphic.DrawPolygon(Pen_Graphics, Specific_Node.Get_Points());

							if (Specific_Node.Get_Color().CompareTo("Black") == 0)
							{
								Board_Graphic.FillPolygon(Solid_Brush_Black, Specific_Node.Get_Points());
							}
							else if (Specific_Node.Get_Color().CompareTo("Gray") == 0)
							{
								Board_Graphic.FillPolygon(Solid_Brush_Gray, Specific_Node.Get_Points());
							}
							else if(Specific_Node.Get_Color().CompareTo("Gold") == 0)
							{
								Board_Graphic.FillPolygon(new SolidBrush(Color.Gold), Specific_Node.Get_Points());
							}
						}

						/* -------------------- Note In Used ----------------- */
						/** ----- Write The Calculation Inside Each Sqaure -----
						 *	Board_Graphic.DrawString((Specific_Node.Get_G_Function() + Specific_Node.Get_H_Function()).ToString(),
						 *  new Font("David", 5), 
						 *  Brushes.Black, Specific_Node.Get_Centre_Node().X, 
						 *  Specific_Node.Get_Centre_Node().Y);
						 **/
						/* --------------------------------------------------- */
					}

					/* Check The Flag Of - Gold Square */
					if(Gold_Square_Exist == true)
					{
						/* Show Error Message To The User */
						MessageBox.Show("Congratulations! You've Passed On Gold Square !",
										"Congratulations!",
										MessageBoxButtons.OK,
										MessageBoxIcon.Information);
					}
				}
			}
		}


		/**
		 * With This Function I Close The Game.
		 **/
		private void Button_Close_Game_Click(object sender, EventArgs e)
		{
			this.Close();
			Environment.Exit(0);
		}


		/* ---------------------------------- A Star Algorithm ---------------------------------- */


		/**
		 * This Function Is The Original AI A* Function.
		 **/
		public void A_Star(List<Node> List_Of_Nodes)
		{
			/* List <Node> */
			List<Node> Open_List = new List<Node>();
			List<Node> Close_List = new List<Node>();

			/* Current Node */
			Node Current = null;

			if (List_Of_Nodes.Count > 0)
			{
				Current = List_Of_Nodes[0];
			}

			Open_List.Add(Current);

			while (Open_List.Count > 0 && Close_List.Contains(List_Of_Nodes[List_Of_Nodes.Count - 1]) == false)
			{
				/* Assign For Finding The Minimum Value */
				Current = Open_List[0];

				if (Open_List.Count > 1)
				{
					/* Find The Min (H + G) Value */
					foreach (Node Specific_Node in Open_List)
					{
						/** ----- Note -----
						 * This 'If Statement' Prevent From Us To Check Node With Himself.
						 **/
						if (Specific_Node.Get_Number_Of_Node().CompareTo(Current.Get_Number_Of_Node()) != 0)
						{
							if ((Current.Get_G_Function() + Current.Get_H_Function()) >=
							  (Specific_Node.Get_H_Function() + Specific_Node.Get_G_Function()))
							{
								Current = Specific_Node;
							}
						}
					}
				}	

				/* Remove The Item From The Open List */
				Open_List.Remove(Current);

				/* Add The Item To The Close List */
				Close_List.Add(Current);

				/* Loop Throught The Node's Children And Siblings */
				foreach (Node Specific_Node in Neighbors_Function(Current, List_Of_Nodes))
				{
					if (Close_List.Contains(Specific_Node) == true)
					{
						/* Continue To The Next Iteration */
						continue;
					}

					/* Otherwise , If It is Already In The Open List */
					if (Open_List.Contains(Specific_Node) == true)
					{
						/* Check If We Beat The G Function Score */
						int New_G_Function = Current.Get_G_Function() + Current.Move_Cost();

						/* Update The Node To Have a New Parent */
						if (Specific_Node.Get_G_Function() > New_G_Function)
						{
							Specific_Node.Set_G_Function(New_G_Function);
							Specific_Node.Set_Parent(Current);
						}
					}

					/* If Its Isn't In The Open List , Calculate The G , H Score For The Node */
					else
					{
						Specific_Node.Set_G_Function(Current.Get_G_Function() + Current.Move_Cost());
						Specific_Node.Set_H_Function(Manhatten_Function(List_Of_Nodes[0], Specific_Node, List_Of_Nodes[List_Of_Nodes.Count - 1]));
						Specific_Node.Set_Parent(Current);
						Open_List.Add(Specific_Node);
					}
				}
			}

			/* If We In The Last Point , We Return The Optimal Path */
			if (Current == List_Of_Nodes[List_Of_Nodes.Count - 1])
			{
				Final_Path = new List<Node>();

				while (Current.Get_Parent() != null)
				{
					Final_Path.Add(Current);
					Current = Current.Get_Parent();
				}

				Final_Path.Add(Current);
				Final_Path.Reverse();
				return;
			}
			else
			{
				/* Show Error Message To The User */
				MessageBox.Show("We Cant Get To The Last Point , So Its Mean That We Don't Have Path In This Board !",
								"Please , Try To Show Another Board",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);

				/* Update - Flag */
				Cant_Get_To_Last_Point = true;
			}
		}


		/**
		 * This Function Over On The Childrens , And Neighbors Nodes Of Current Node. 
		 **/
		public List<Node> Neighbors_Function(Node Current, List<Node> List_Of_Nodes)
		{
			Point Center_Point_Of_Node = Current.Get_Centre_Node();
			List<Node> Neighbors_Nodes = new List<Node>();
			foreach (Node Specific_Node in List_Of_Nodes)
			{
				if (((Center_Point_Of_Node.X - Sqaure_Size) == Specific_Node.Get_Centre_Node().X) && (Center_Point_Of_Node.Y == Specific_Node.Get_Centre_Node().Y))
				{
					Neighbors_Nodes.Add(Specific_Node);
				}
				else if ((Center_Point_Of_Node.X == Specific_Node.Get_Centre_Node().X) && ((Center_Point_Of_Node.Y - Sqaure_Size) == Specific_Node.Get_Centre_Node().Y))
				{
					Neighbors_Nodes.Add(Specific_Node);
				}
				else if ((Center_Point_Of_Node.X == Specific_Node.Get_Centre_Node().X) && ((Center_Point_Of_Node.Y + Sqaure_Size) == Specific_Node.Get_Centre_Node().Y))
				{
					Neighbors_Nodes.Add(Specific_Node);
				}
				else if (((Center_Point_Of_Node.X + Sqaure_Size) == Specific_Node.Get_Centre_Node().X) && (Center_Point_Of_Node.Y == Specific_Node.Get_Centre_Node().Y))
				{
					Neighbors_Nodes.Add(Specific_Node);
				}
			}

			/* Remain Only The Sibilngs That With Gray / Gold Color */
			foreach (Node Specific_Neighbor in Neighbors_Nodes.ToList())
			{
				if (Specific_Neighbor.Get_Color().CompareTo("Black") == 0)
				{
					Neighbors_Nodes.Remove(Specific_Neighbor);
				}
			}

			/* Set Property Of Number Of Neighbors */
			Current.Set_Number_Of_Neighbors(Neighbors_Nodes.Count);

			return Neighbors_Nodes;
		}
		

		/**
		 * This Function Calculate The Heuristic Distance.
		 **/
		public int Manhatten_Function(Node Start_Node, Node Specific_Node, Node Goal_Node)
		{
			/* First Calculation */
			int Cordinate_X_1 = Specific_Node.Get_Centre_Node().X - Goal_Node.Get_Centre_Node().X;
			int Cordinate_Y_1 = Specific_Node.Get_Centre_Node().Y - Goal_Node.Get_Centre_Node().Y;
			int Cordinate_X_2 = Start_Node.Get_Centre_Node().X - Goal_Node.Get_Centre_Node().X;
			int Cordinate_Y_2 = Start_Node.Get_Centre_Node().Y - Goal_Node.Get_Centre_Node().Y;

			/* Second Calculation */
			int Manhatten_Value = Math.Abs(Specific_Node.Get_Centre_Node().X - Goal_Node.Get_Centre_Node().X) + Math.Abs(Specific_Node.Get_Centre_Node().Y - Goal_Node.Get_Centre_Node().Y);

			/* Return Manhatten - Value */
			return Manhatten_Value + Math.Abs((Cordinate_X_1 * Cordinate_Y_2) - (Cordinate_X_2 * Cordinate_Y_1));
		}


		/* ---------------------------------- Not In Used --------------------------------------- */


		/**
		 * This Function Check The Number Of Neighbors.
		 **/
		public int Check_Number_Of_Neighbors(Node Local_Node, List<Node> List_Of_Nodes)
		{
			Point Center_Point_Of_Node = Local_Node.Get_Centre_Node();
			List<Node> Neighbors_Nodes = new List<Node>();
			foreach (Node Specific_Node in List_Of_Nodes)
			{
				if (((Center_Point_Of_Node.X - Sqaure_Size) == Specific_Node.Get_Centre_Node().X) && (Center_Point_Of_Node.Y == Specific_Node.Get_Centre_Node().Y))
				{
					Neighbors_Nodes.Add(Specific_Node);
				}
				else if ((Center_Point_Of_Node.X == Specific_Node.Get_Centre_Node().X) && ((Center_Point_Of_Node.Y - Sqaure_Size) == Specific_Node.Get_Centre_Node().Y))
				{
					Neighbors_Nodes.Add(Specific_Node);
				}
				else if ((Center_Point_Of_Node.X == Specific_Node.Get_Centre_Node().X) && ((Center_Point_Of_Node.Y + Sqaure_Size) == Specific_Node.Get_Centre_Node().Y))
				{
					Neighbors_Nodes.Add(Specific_Node);
				}
				else if (((Center_Point_Of_Node.X + Sqaure_Size) == Specific_Node.Get_Centre_Node().X) && (Center_Point_Of_Node.Y == Specific_Node.Get_Centre_Node().Y))
				{
					Neighbors_Nodes.Add(Specific_Node);
				}
			}

			/* Remain Only The Sibilngs That With Gray / Gold Color */
			foreach (Node Specific_Neighbor in Neighbors_Nodes.ToList())
			{
				if (Specific_Neighbor.Get_Color().CompareTo("Black") == 0)
				{
					Neighbors_Nodes.Remove(Specific_Neighbor);
				}
			}

			/* Return The Number Of The Node's */
			return Neighbors_Nodes.Count;
		}
	}
}
