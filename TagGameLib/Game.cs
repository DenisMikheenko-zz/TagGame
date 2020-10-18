using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TagGameLib
{
    public class Game
    {
        private List<Tag> _tags;
        private int _size;

        /// <summary>
        /// The method starts the game
        /// </summary>
        /// <param name="size">The size of the game field</param>
        public void Start(int size)
        {
            _size = size;
            Init();
            Show();
            Console.WriteLine();
            //Move("5");
            //Show();
        }

        private void Init()
        {
            _tags = new List<Tag>();

            var tagNamesInitial = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };

            var tagNames = ShuffleIntArray(tagNamesInitial);

            int tagNameIndex = 0;
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    _tags.Add(new Tag() { Name = tagNames[tagNameIndex++].ToString(), Position = new Position() { X= j, Y=i}});
                }
            }
        }

        private void Move(string tagName)
        {

            
            var nullTagIndex = _tags.FindLastIndex(c => c.Name == 0.ToString());
            
            var tagIndexToMove =_tags.FindLastIndex(c => c.Name == tagName);

            var nullPosition = _tags[nullTagIndex].Position;
            var tagToMovePosition = _tags[tagIndexToMove].Position;

            var diffX =Math.Abs(nullPosition.X - tagToMovePosition.X);
            var diffY = Math.Abs(nullPosition.Y - tagToMovePosition.Y);

            if (diffX > 1 || diffY > 1) throw new Exception("The tag can not be moved");

            // Eliminates the possibility of moving the tag diagonally.
            if (diffX==1 && diffY==1) throw new Exception("The tag can not be moved");

            _tags[nullTagIndex].Position = tagToMovePosition;
            _tags[tagIndexToMove].Position = nullPosition;
        }

        private void Show()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write(_tags.Where(t=>t.Position.Y == i)
                                        .Where(t=>t.Position.X == j)
                                        .FirstOrDefault().Name + "     ");
                }
                Console.WriteLine();
            }
        }

        private int[] ShuffleIntArray(int[] arr)
        {
            Random rand = new Random();

            for (int i = arr.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                int tmp = arr[j];
                arr[j] = arr[i];
                arr[i] = tmp;
            }

            return arr;
        }


    }
}
