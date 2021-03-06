// Fig. 21.5: LinkedListTest.cs
// Using LinkedLists.
using System;
using System.Collections.Generic;

class LinkedListTest
{
   private static readonly string[] colors =
      {"black", "yellow", "green", "blue", "violet", "silver"};
   private static readonly string[] colors2 =
      {"gold", "white", "brown", "blue", "gray"};

   // set up and manipulate LinkedList objects
   static void Main()
   {
      var list1 = new LinkedList<string>();

      // add elements to first linked list
      foreach (var color in colors)
      {
         list1.AddLast(color);
      }

      // add elements to second linked list via constructor
      var list2 = new LinkedList<string>(colors2);

      Concatenate(list1, list2); // concatenate list2 onto list1
      PrintList(list1); // display list1 elements

      Console.WriteLine("\nConverting strings in list1 to uppercase\n");
      ToUppercaseStrings(list1); // convert to uppercase string
      PrintList(list1); // display list1 elements

      Console.WriteLine("\nDeleting strings between BLACK and BROWN\n");
      RemoveItemsBetween(list1, "BLACK", "BROWN");

      PrintList(list1); // display list1 elements
      PrintReversedList(list1); // display list in reverse order
   }

   // display list contents
   private static void PrintList<T>(LinkedList<T> list)
   {
      Console.WriteLine("Linked list: ");

      foreach (var value in list)
      {
         Console.Write($"{value} ");
      }

      Console.WriteLine();
   }

   // concatenate the second list on the end of the first list
   private static void Concatenate<T>(
      LinkedList<T> list1, LinkedList<T> list2)
   {
      // concatenate lists by copying element values     
      // in order from the second list to the first list
      foreach (var value in list2)
      {
         list1.AddLast(value); // add new node        
      }
   }

   // locate string objects and convert to uppercase
   private static void ToUppercaseStrings(LinkedList<string> list)
   {
      // iterate over the list by using the nodes                     
      LinkedListNode<string> currentNode = list.First;

      while (currentNode != null)
      {
         string color = currentNode.Value; // get value in node       
         currentNode.Value = color.ToUpper(); // convert to uppercase 
         currentNode = currentNode.Next; // get next node             
      }
   }

   // delete list items between two given items
   private static void RemoveItemsBetween<T>(
      LinkedList<T> list, T startItem, T endItem)
   {
      // get the nodes corresponding to the start and end item
      LinkedListNode<T> currentNode = list.Find(startItem);
      LinkedListNode<T> endNode = list.Find(endItem);

      // remove items after the start item
      // until we find the last item or the end of the linked list
      while ((currentNode.Next != null) && (currentNode.Next != endNode))
      {
         list.Remove(currentNode.Next); // remove next node
      }
   }

   // display reversed list
   private static void PrintReversedList<T>(LinkedList<T> list)
   {
      Console.WriteLine("Reversed List:");

      // iterate over the list by using the nodes
      LinkedListNode<T> currentNode = list.Last;

      while (currentNode != null)
      {
         Console.Write($"{currentNode.Value} ");
         currentNode = currentNode.Previous; // get previous node
      }

      Console.WriteLine();
   }
}


/**************************************************************************
 * (C) Copyright 1992-2017 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
