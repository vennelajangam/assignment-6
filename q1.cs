﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;


namespace ProductInventory
{
    class Product : IEquatable<int>
    {
        private int id;
        private float price;
        private bool isDefective;


        public Product() { }


        public Product(int id, float price, bool isDefective)
        {
            this.id = id;
            this.price = price;
            this.isDefective = isDefective;
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }




        public float Price
        {
            get { return price; }
            set { price = value; }
        }




        public bool IsDefective
        {
            get { return isDefective; }
            set { isDefective = value; }
        }


        public bool Equals(int id)
        {
            return this.id == id;
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Product, int> products = new Dictionary<Product, int>();


            int ch = -1;
            while (ch != 5)
            {
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Remove Product");
                Console.WriteLine("3. Update Product Quantity");
                Console.WriteLine("4. Display total value of the inventory");
                Console.WriteLine("5. Exit");
                Console.Write("Enter Your choice : ");
                ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        int id = (new Random()).Next(1000, 10000);
                        Console.WriteLine("The product ID: {0}", id);
                        Console.Write("Enter the product price: ");
                        float price = float.Parse(Console.ReadLine());
                        Console.Write("Enter the product quantities: ");
                        int quantities = int.Parse(Console.ReadLine());
                        Console.Write("Is this product defective? y/n: ");
                        string answer = Console.ReadLine();
                        bool isDefective = false;
                        if (answer.ToLower().CompareTo("y") == 0)
                        {
                            isDefective = true;
                        }
                        Product p = new Product(id, price, isDefective);


                        if (!p.IsDefective)
                        {
                            products.Add(p, quantities);
                            Console.WriteLine("\nA new product has been added.\n");
                        }
                        break;
                    case 2:
                        Console.Write("Enter the product ID to remove: ");
                        id = int.Parse(Console.ReadLine());
                        Product selectedProduct = null;
                        foreach (var product in products)
                        {
                            if (product.Key.Id == id)
                            {
                                selectedProduct = product.Key;
                                break;
                            }
                        }
                        if (selectedProduct != null)
                        {
                            products.Remove(selectedProduct);
                            Console.WriteLine("\nThe product has been removed.\n");
                        }
                        else
                        {
                            Console.WriteLine("\nA product does not exist.\n");
                        }
                        break;
                    case 3:
                        Console.Write("Enter the product ID to update product quantity: ");
                        id = int.Parse(Console.ReadLine());
                        selectedProduct = null;
                        foreach (var product in products)
                        {
                            if (product.Key.Id == id)
                            {
                                selectedProduct = product.Key;
                                break;
                            }
                        }
                        if (selectedProduct != null)
                        {
                            Console.Write("Enter a new product quantities: ");
                            quantities = int.Parse(Console.ReadLine());
                            products[selectedProduct] = quantities;
                            Console.WriteLine("\nThe product quantity has been updated.\n");
                        }
                        else
                        {
                            Console.WriteLine("\nA product does not exist.\n");
                        }
                        break;
                    case 4:
                        float total = 0;
                        foreach (var product in products)
                        {
                            total += product.Key.Price * product.Value;
                        }
                        Console.WriteLine("The total value of the inventory: {0}", total.ToString("N2"));
                        break;
                    case 5:
                        //exit


                        break;
                }
            }




            Console.ReadLine();
        }
    }
}