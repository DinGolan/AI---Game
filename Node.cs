using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI___Obstacle_Board
{
	public class Node
	{
		/* Attributes */
		public int Number_Of_Node;
		public int Value;
		public string Color;
		public Point[] Points;
		public Node Parent; 
		public int H_Function;
		public int G_Function;
		public int Number_Of_Neighbors;


		/* ---------------------------------- Constructor's ------------------------------------- */


		/**
		 * Constructor Of - Node.
		 **/
		public Node(int Value , Point[] Points)
		{
			this.Value = Value;
			this.Points = Points;
			Parent = null;
			H_Function = 0;
			G_Function = 0;
		}


		/* ---------------------------------- Getters & Setters --------------------------------- */


		/**
		 * Get - Number Of Node.
		 **/
		public int Get_Number_Of_Node()
		{
			return this.Number_Of_Node;
		}


		/**
		 * Set - Number_Of_Node.
		 **/
		public void Set_Number_Of_Node(int Number_Of_Node)
		{
			this.Number_Of_Node = Number_Of_Node;
		}


		/**
		 * Get - Value.
		 **/
		public int Get_Value()
		{
			return this.Value;
		}


		/**
		 * Set - Value.
		 **/
		public void Set_Value(int Value)
		{
			this.Value = Value;
		}


		/**
		 * Get - Point.
		 **/
		public Point[] Get_Points()
		{
			return this.Points;
		}


		/**
		 * Set - Point.
		 **/
		public void Set_Point(Point[] Points)
		{
			this.Points = Points;
		}


		/**
		 * Get - Parent.
		 **/
		public Node Get_Parent()
		{
			return this.Parent;
		}


		/**
		 * Set - Parent.
		 **/
		public void Set_Parent(Node Parent)
		{
			this.Parent = Parent;
		}


		/**
		 * Get - H Function.
		 **/
		public int Get_H_Function()
		{
			return this.H_Function;
		}


		/**
		 * Set - H Function
		 **/
		public void Set_H_Function(int H_Function)
		{
			this.H_Function = H_Function;
		}


		/**
		 * Get - G Function.
		 **/
		public int Get_G_Function()
		{
			return this.G_Function;
		}


		/**
		 * Set - G Function
		 **/
		public void Set_G_Function(int G_Function)
		{
			this.G_Function = G_Function;
		}


		/**
		 * Get - Color.
		 **/
		public string Get_Color()
		{
			return this.Color;
		}


		/**
		 * Set - Color.
		 **/
		public void Set_Color(string Color)
		{
			this.Color = Color;
		}


		/**
		 * Get - Number Of Neighbors
		 **/
		public int Get_Number_Of_Neighbors()
		{
			return this.Number_Of_Neighbors;
		}


		/**
		 * Set - Number Of Neighbors.
		 **/
		public void Set_Number_Of_Neighbors(int Number_Of_Neighbors)
		{
			this.Number_Of_Neighbors = Number_Of_Neighbors;
		}


		/* ---------------------------------- Function For Each Node ---------------------------- */


		/**
		 * This Function Responsible For The G Value.
		 **/
		public int Move_Cost()
		{
			if(this.Value == -1)
			{
				return 0;
			}

			return 1;
		}


		/**
		 * This Function Gets The Centre Points Of Node.
		 **/
		public Point Get_Centre_Node()
		{
			int Center_Coordinate_X = Convert.ToInt32(((this.Points[3].X + this.Points[0].X) / 2));
			int Center_Coordinate_Y = Convert.ToInt32(((this.Points[1].Y + this.Points[0].Y) / 2));

			/* Return ===> Center Point */
			return new Point(Center_Coordinate_X, Center_Coordinate_Y);
		}
	}
}
