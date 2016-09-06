﻿namespace CampusSystem.Services.Data
{
    using System;
    using System.Linq;
    using CampusSystem.Data.Common;
    using CampusSystem.Data.Models;
    using Contracts;

    public class RoomService : IRoomService
    {
        private readonly IDbRepository<Room> rooms;
        private readonly IDbRepository<Floor> floors;
        private readonly IRepository<User> students;

        public RoomService(IDbRepository<Room> rooms, IDbRepository<Floor> floors, IRepository<User> students)
        {
            this.rooms = rooms;
            this.floors = floors;
            this.students = students;
        }

        public IQueryable<Room> GetAllFreeRooms(int betsCount)
        {
            return this.rooms.All().Where(x => x.BedsCount >= betsCount);
        }

        public IQueryable<Room> GetFreeRooms(bool hasBalcon)
        {
            return this.rooms.All().Where(x => x.HasBalcon == hasBalcon);
        }

        public IQueryable<Room> GetRooms(int buildingId, int floorId, bool hasBalcon)
        {
            var floorsResult = this.floors.All().Where(x => x.BuildingId == buildingId);
            return this.rooms.All().Where(x => x.FloorId == floorId && x.HasBalcon == hasBalcon);
        }

        public IQueryable<Room> GetFreeRoomsByFloorId(int floorId)
        {
            return this.rooms.All().Where(x => x.FloorId == floorId && (x.BedsCount - x.Students.Count) > 0);
        }

        public Room AssignUserFoorRoom(int id, string userId)
        {
            var room = this.rooms.GetById(id);
            var student = this.students.GetById(userId);
            room.Students.Add(student);
            this.rooms.Save();
            return room;
        }

        public IQueryable<Room> GetRoomsByBuildingId(int buildingId)
        {
            return this.rooms.All().Where(x => x.Floor.BuildingId == buildingId);
        }

        public void LeaveRoom(int id, string userId)
        {
            var room = this.rooms.GetById(id);
            var student = this.students.GetById(userId);
            room.Students.Remove(student);
            this.rooms.Save();
        }
    }
}
