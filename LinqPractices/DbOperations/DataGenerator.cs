﻿using LinqPractices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractices.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize()
        {
            using (var context = new LinqDbContext())
            {
                if (context.Students.Any())
                {
                    return;
                }
                context.Students.AddRange
                    (
                    new Student()
                    {
                        
                        Name = "Ayse",
                        Surname = "Yilmaz",
                        ClassId = 1
                    },
                    new Student()
                    {
                        
                        Name = "Deniz",
                        Surname = "Arda",
                        ClassId = 1
                    },
                    new Student()
                    {
                        
                        Name = "Umut",
                        Surname = "Arda",
                        ClassId = 2
                    },
                    new Student()
                    {
                        
                        Name = "Merve",
                        Surname = "Yilmaz",
                        ClassId = 2
                    }
                    );
                context.SaveChanges();
                }
            }
        }
    }
