﻿using ScramBoardAPI.Models;

namespace ScramBoardAPI.DTO
{
    public class BoardDTO
    {
        public string UUID { get; set; }
        public string Name { get; set; }

        public BoardDTO(Board board)
        {
            UUID = board.GetUUID();
            Name = board.GetName();
        }
    }
}
