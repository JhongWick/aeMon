using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Migrations.Seeds
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    public class RoleDetails
    {
        public static void Seed(DataAccessLayer.DBContext context)
        {

            if (context.RoleDetails.Count() <= 0)
            {


                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 1,
                    RoleId = 3,
                    ModuleId = 1,
                    IsAllowed = true
                });

                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 2,
                    RoleId = 1,
                    ModuleId = 1,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 3,
                    RoleId = 1,
                    ModuleId = 2,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 4,
                    RoleId = 1,
                    ModuleId = 3,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 5,
                    RoleId = 2,
                    ModuleId = 1,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 6,
                    RoleId = 2,
                    ModuleId = 2,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 7,
                    RoleId = 2,
                    ModuleId = 3,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 8,
                    RoleId = 3,
                    ModuleId = 2,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 9,
                    RoleId = 3,
                    ModuleId = 3,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 10,
                    RoleId = 1,
                    ModuleId = 4,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 11,
                    RoleId = 1,
                    ModuleId = 5,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 12,
                    RoleId = 1,
                    ModuleId = 6,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 13,
                    RoleId = 1,
                    ModuleId = 7,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 14,
                    RoleId = 1,
                    ModuleId = 8,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 15,
                    RoleId = 1,
                    ModuleId = 9,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 16,
                    RoleId = 1,
                    ModuleId = 10,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 17,
                    RoleId = 1,
                    ModuleId = 11,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 18,
                    RoleId = 1,
                    ModuleId = 12,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 19,
                    RoleId = 1,
                    ModuleId = 13,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 20,
                    RoleId = 1,
                    ModuleId = 14,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 21,
                    RoleId = 1,
                    ModuleId = 15,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 22,
                    RoleId = 1,
                    ModuleId = 16,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 23,
                    RoleId = 1,
                    ModuleId = 17,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 24,
                    RoleId = 3,
                    ModuleId = 4,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 25,
                    RoleId = 3,
                    ModuleId = 5,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 26,
                    RoleId = 3,
                    ModuleId = 6,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 27,
                    RoleId = 3,
                    ModuleId = 7,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 28,
                    RoleId = 3,
                    ModuleId = 8,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 29,
                    RoleId = 3,
                    ModuleId = 9,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 30,
                    RoleId = 3,
                    ModuleId = 10,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 31,
                    RoleId = 2,
                    ModuleId = 11,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 32,
                    RoleId = 2,
                    ModuleId = 12,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 33,
                    RoleId = 2,
                    ModuleId = 13,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 34,
                    RoleId = 2,
                    ModuleId = 14,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 35,
                    RoleId = 2,
                    ModuleId = 15,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 36,
                    RoleId = 2,
                    ModuleId = 16,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 37,
                    RoleId = 2,
                    ModuleId = 17,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 38,
                    RoleId = 1,
                    ModuleId = 18,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 39,
                    RoleId = 1,
                    ModuleId = 19,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 40,
                    RoleId = 1,
                    ModuleId = 20,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 41,
                    RoleId = 1,
                    ModuleId = 21,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 42,
                    RoleId = 1,
                    ModuleId = 22,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 43,
                    RoleId = 1,
                    ModuleId = 23,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 44,
                    RoleId = 1,
                    ModuleId = 24,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 45,
                    RoleId = 1,
                    ModuleId = 25,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 46,
                    RoleId = 1,
                    ModuleId = 26,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 47,
                    RoleId = 1,
                    ModuleId = 27,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 48,
                    RoleId = 1,
                    ModuleId = 28,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 49,
                    RoleId = 1,
                    ModuleId = 29,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 50,
                    RoleId = 1,
                    ModuleId = 30,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 51,
                    RoleId = 1,
                    ModuleId = 31,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 52,
                    RoleId = 1,
                    ModuleId = 32,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 53,
                    RoleId = 1,
                    ModuleId = 34,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 54,
                    RoleId = 1,
                    ModuleId = 33,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 55,
                    RoleId = 1,
                    ModuleId = 35,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 56,
                    RoleId = 1,
                    ModuleId = 36,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 57,
                    RoleId = 1,
                    ModuleId = 37,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 58,
                    RoleId = 1,
                    ModuleId = 38,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 59,
                    RoleId = 3,
                    ModuleId = 21,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 60,
                    RoleId = 3,
                    ModuleId = 22,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 61,
                    RoleId = 3,
                    ModuleId = 23,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 62,
                    RoleId = 3,
                    ModuleId = 24,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 63,
                    RoleId = 3,
                    ModuleId = 25,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 64,
                    RoleId = 3,
                    ModuleId = 26,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 65,
                    RoleId = 3,
                    ModuleId = 27,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 66,
                    RoleId = 3,
                    ModuleId = 28,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 67,
                    RoleId = 3,
                    ModuleId = 29,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 68,
                    RoleId = 3,
                    ModuleId = 30,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 69,
                    RoleId = 1,
                    ModuleId = 39,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 70,
                    RoleId = 1,
                    ModuleId = 40,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 71,
                    RoleId = 1,
                    ModuleId = 41,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 72,
                    RoleId = 1,
                    ModuleId = 42,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 73,
                    RoleId = 1,
                    ModuleId = 43,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 74,
                    RoleId = 3,
                    ModuleId = 39,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 75,
                    RoleId = 3,
                    ModuleId = 40,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 76,
                    RoleId = 3,
                    ModuleId = 41,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 77,
                    RoleId = 3,
                    ModuleId = 42,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 78,
                    RoleId = 3,
                    ModuleId = 43,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 79,
                    RoleId = 2,
                    ModuleId = 6,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 80,
                    RoleId = 2,
                    ModuleId = 41,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 81,
                    RoleId = 2,
                    ModuleId = 42,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 82,
                    RoleId = 2,
                    ModuleId = 43,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 83,
                    RoleId = 3,
                    ModuleId = 11,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 84,
                    RoleId = 3,
                    ModuleId = 12,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 85,
                    RoleId = 3,
                    ModuleId = 13,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 86,
                    RoleId = 3,
                    ModuleId = 14,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 87,
                    RoleId = 3,
                    ModuleId = 15,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 88,
                    RoleId = 3,
                    ModuleId = 16,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 89,
                    RoleId = 3,
                    ModuleId = 17,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 90,
                    RoleId = 3,
                    ModuleId = 18,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 91,
                    RoleId = 3,
                    ModuleId = 19,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 92,
                    RoleId = 3,
                    ModuleId = 20,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 93,
                    RoleId = 3,
                    ModuleId = 31,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 94,
                    RoleId = 3,
                    ModuleId = 32,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 95,
                    RoleId = 3,
                    ModuleId = 33,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 96,
                    RoleId = 3,
                    ModuleId = 34,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 97,
                    RoleId = 3,
                    ModuleId = 35,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 98,
                    RoleId = 3,
                    ModuleId = 36,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 99,
                    RoleId = 3,
                    ModuleId = 37,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 100,
                    RoleId = 3,
                    ModuleId = 38,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 101,
                    RoleId = 2,
                    ModuleId = 4,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 102,
                    RoleId = 2,
                    ModuleId = 5,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 103,
                    RoleId = 2,
                    ModuleId = 7,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 104,
                    RoleId = 2,
                    ModuleId = 8,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 105,
                    RoleId = 2,
                    ModuleId = 9,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 106,
                    RoleId = 2,
                    ModuleId = 10,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 107,
                    RoleId = 2,
                    ModuleId = 18,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 108,
                    RoleId = 2,
                    ModuleId = 19,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 109,
                    RoleId = 2,
                    ModuleId = 20,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 110,
                    RoleId = 2,
                    ModuleId = 21,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 111,
                    RoleId = 2,
                    ModuleId = 22,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 112,
                    RoleId = 2,
                    ModuleId = 23,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 113,
                    RoleId = 2,
                    ModuleId = 24,
                    IsAllowed = true
                });

                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 114,
                    RoleId = 2,
                    ModuleId = 25,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 115,
                    RoleId = 2,
                    ModuleId = 26,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 116,
                    RoleId = 2,
                    ModuleId = 27,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 117,
                    RoleId = 2,
                    ModuleId = 28,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 118,
                    RoleId = 2,
                    ModuleId = 29,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 119,
                    RoleId = 2,
                    ModuleId = 30,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 120,
                    RoleId = 2,
                    ModuleId = 31,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 121,
                    RoleId = 2,
                    ModuleId = 32,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 122,
                    RoleId = 2,
                    ModuleId = 33,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 123,
                    RoleId = 2,
                    ModuleId = 34,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 124,
                    RoleId = 2,
                    ModuleId = 35,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 125,
                    RoleId = 2,
                    ModuleId = 36,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 126,
                    RoleId = 2,
                    ModuleId = 37,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 127,
                    RoleId = 2,
                    ModuleId = 38,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 128,
                    RoleId = 2,
                    ModuleId = 39,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 129,
                    RoleId = 2,
                    ModuleId = 40,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 130,
                    RoleId = 2,
                    ModuleId = 44,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 131,
                    RoleId = 1,
                    ModuleId = 44,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 132,
                    RoleId = 3,
                    ModuleId = 44,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 133,
                    RoleId = 2,
                    ModuleId = 45,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 134,
                    RoleId = 2,
                    ModuleId = 46,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 135,
                    RoleId = 2,
                    ModuleId = 47,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 136,
                    RoleId = 2,
                    ModuleId = 48,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 137,
                    RoleId = 1,
                    ModuleId = 45,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 138,
                    RoleId = 1,
                    ModuleId = 46,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 139,
                    RoleId = 1,
                    ModuleId = 47,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 140,
                    RoleId = 1,
                    ModuleId = 48,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 141,
                    RoleId = 3,
                    ModuleId = 45,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 142,
                    RoleId = 3,
                    ModuleId = 46,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 143,
                    RoleId = 3,
                    ModuleId = 47,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 144,
                    RoleId = 3,
                    ModuleId = 48,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 145,
                    RoleId = 2,
                    ModuleId = 49,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 146,
                    RoleId = 2,
                    ModuleId = 50,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 147,
                    RoleId = 2,
                    ModuleId = 51,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 148,
                    RoleId = 2,
                    ModuleId = 52,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 149,
                    RoleId = 2,
                    ModuleId = 53,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 150,
                    RoleId = 1,
                    ModuleId = 49,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 151,
                    RoleId = 1,
                    ModuleId = 50,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 152,
                    RoleId = 1,
                    ModuleId = 51,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 153,
                    RoleId = 1,
                    ModuleId = 52,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 154,
                    RoleId = 1,
                    ModuleId = 53,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 155,
                    RoleId = 2,
                    ModuleId = 54,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 156,
                    RoleId = 1,
                    ModuleId = 54,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 157,
                    RoleId = 3,
                    ModuleId = 49,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 158,
                    RoleId = 3,
                    ModuleId = 50,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 159,
                    RoleId = 3,
                    ModuleId = 51,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 160,

                    RoleId = 3,
                    ModuleId = 52,
                    IsAllowed = false
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 161,
                    RoleId = 3,
                    ModuleId = 53,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 162,
                    RoleId = 3,
                    ModuleId = 54,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 163,
                    RoleId = 2,
                    ModuleId = 55,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 164,
                    RoleId = 3,
                    ModuleId = 55,
                    IsAllowed = true
                });
                context.RoleDetails.Add(new RoleDetail
                {
                    Id = 165,
                    RoleId = 1,
                    ModuleId = 55,
                    IsAllowed = true
                });


            }

            context.SaveChanges();
        }
    }
}
