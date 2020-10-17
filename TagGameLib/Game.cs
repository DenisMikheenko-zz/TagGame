﻿using System;
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
            Move("15");
        }

        private void Init()
        {
            _tags = new List<Tag>();
            int tagName = 0;
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    _tags.Add(new Tag() { Name = tagName++.ToString(), Position = new Position() { X= j, Y=i}});
                }
            }
        }

        private void Move(string tagName)
        {
            var nullTagIndex = _tags.FindLastIndex(c => c.Name == tagName);
            if (nullTagIndex == null) throw new NullReferenceException("nullTagIndex"); 
            
            var tagIndexToMove =_tags.FindLastIndex(c => c.Name == tagName);
            if (tagIndexToMove == null) throw new NullReferenceException("tagIndexToMove is null");

            var nullPosition = _tags[nullTagIndex].Position;
            var tagToMovePosition = _tags[tagIndexToMove].Position;

            _tags[nullTagIndex].Position = tagToMovePosition;
            _tags[tagIndexToMove].Position = nullPosition;
        }

        private void Show()
        {

        }
    }
}