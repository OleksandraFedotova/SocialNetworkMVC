using Newtonsoft.Json;
using SocialNetworkMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace SocialNetworkMVC.Services
{
    public class DataService : IDataService
    {
        private static List<User> users;
        /*= new List<User>
        {
            new User
            {
                Id=1,
                Avatar="https://www.w3schools.com/w3images/avatar2.png",
                CreatedAt=DateTime.Today,
                Name="fdnjknvlkfdv",
                Email="fkkfj@jdfjf",
                Posts=new List<Post>
                {
                    new Post
                    {
                        Id=2,
                        Body="11111111111234567",
                        Likes=7,
                        Title="ertyuiop[",
                        createdAt=DateTime.Today,
                        UserId=1,
                        Comments=new List<Comment>
                        {
                            new Comment
                            {
                                Id=1,
                                Body="3333333333333399999",
                                CreatedAt=DateTime.Today,
                                Likes=8,
                                PostId=2,
                                UserId=1
                            }
                        }
                    }
                },
                Todos=new List<Todo>
                {
                    new Todo
                    {
                        Id=1,
                        CreatedAt=DateTime.Today,
                        IsComlete=true,
                        Name="jjshdcl",
                        UserId=1
                    },
                     new Todo
                    {
                        Id=2,
                        CreatedAt=DateTime.Today,
                        IsComlete=false,
                        Name="jjshdcl",
                        UserId=1
                    },
                     new Todo
                    {
                        Id=3,
                        CreatedAt=DateTime.Today,
                        IsComlete=true,
                        Name="jjshdcl",
                        UserId=1
                    }
                }
            },
              new User
            {
                Id=2,
                Avatar="https://www.w3schools.com/w3images/avatar2.png",
                CreatedAt=DateTime.Today,
                Email="fkkfj@jdfjf",
                Name="fdnjknvlkfdv",
                Posts=new List<Post>
                {
                    new Post
                    {
                        Id=1,
                        Body="11111111111234567",
                        Likes=7,
                        Title="ertyuiop[",
                        createdAt=DateTime.Today,
                        UserId=2,
                        Comments=new List<Comment>
                        {
                            new Comment
                            {
                                Id=1,
                                Body="999999999999",
                                CreatedAt=DateTime.Today,
                                Likes=8,
                                PostId=1,
                                UserId=2
                            }
                        }

                    }
                },
                Todos=new List<Todo>
                {
                    new Todo
                    {
                        Id=3,
                        CreatedAt=DateTime.Today,
                        IsComlete=false,
                        Name="jjshdcl",
                        UserId=2
                    }
                }
            },
        }
            
            ;
        private static List<Post> posts= new List<Post>
        {
             new Post
                    {
                        Id=2,
                        Body="11111111111234567",
                        Likes=7,
                        Title="ertyuiop[",
                        createdAt=DateTime.Today,
                        UserId=1,
                        Comments=new List<Comment>
                        {
                            new Comment
                            {
                                Id=1,
                                Body="3333333333333399999",
                                CreatedAt=DateTime.Today,
                                Likes=8,
                                PostId=2,
                                UserId=1
                            }
                        }
                    },
              new Post
                    {
                        Id=1,
                        Body="11111111111234567",
                        Likes=7,
                        Title="ertyuiop[",
                        createdAt=DateTime.Today,
                        UserId=2,
                        Comments=new List<Comment>
                        {
                            new Comment
                            {
                                Id=1,
                                Body="999999999999",
                                CreatedAt=DateTime.Today,
                                Likes=8,
                                PostId=1,
                                UserId=2
                            }
                        }

                    }

        };*/

       private static List<Post> posts;
        private static List<Todo> todos;
        private static List<Comment> comments;
        private static List<Address> addresses;

       public DataService()
        {
            HttpClient client = new HttpClient();


            #region UsersResponse
            var usersResponse = client.GetAsync("https://5b128555d50a5c0014ef1204.mockapi.io/users")
                .ContinueWith((taskwithresponse) =>
                {
                    var resp = taskwithresponse.Result;
                    var jsonString = resp.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    users = JsonConvert.DeserializeObject<List<User>>(jsonString.Result);

                });
            usersResponse.Wait();
            #endregion
            #region PostsResponse
            var postsResponse = client.GetAsync("https://5b128555d50a5c0014ef1204.mockapi.io/posts")
                .ContinueWith((taskwithresponse) =>
                {
                    var resp = taskwithresponse.Result;
                    var jsonString = resp.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    posts = JsonConvert.DeserializeObject<List<Post>>(jsonString.Result);

                });
            postsResponse.Wait();
            #endregion
            #region CommentsResponse
            var commentsResponse = client.GetAsync("https://5b128555d50a5c0014ef1204.mockapi.io/comments")
                .ContinueWith((taskwithresponse) =>
                {
                    var resp = taskwithresponse.Result;
                    var jsonString = resp.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    comments = JsonConvert.DeserializeObject<List<Comment>>(jsonString.Result);

                });
            commentsResponse.Wait();
            #endregion
            #region TodosResponse
            var todosResponse = client.GetAsync("https://5b128555d50a5c0014ef1204.mockapi.io/todos")
                .ContinueWith((taskwithresponse) =>
                {
                    var resp = taskwithresponse.Result;
                    var jsonString = resp.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    todos = JsonConvert.DeserializeObject<List<Todo>>(jsonString.Result);

                });
            todosResponse.Wait();
            #endregion
            #region AddressesResponse
            var addressesResponse = client.GetAsync("https://5b128555d50a5c0014ef1204.mockapi.io/address")
                .ContinueWith((taskwithresponse) =>
                {
                    var resp = taskwithresponse.Result;
                    var jsonString = resp.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    addresses = JsonConvert.DeserializeObject<List<Address>>(jsonString.Result);

                });
            addressesResponse.Wait();
            #endregion

            var MyStructure = users.Select(user => new User
            {
                Avatar = user.Avatar,
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
            }).ToList();

            foreach (User u in users)
            {
                u.Address = addresses.Where(addr => addr.UserId == u.Id)
                                  .Select(address => new Address
                                  {
                                      Id = address.Id,
                                      City = address.City,
                                      Country = address.Country,
                                      Zip = address.Zip,
                                      Street = address.Street
                                  }).FirstOrDefault();
                u.Todos = todos.Where(todo => todo.UserId == u.Id)
                                  .Select(td => new Todo
                                  {
                                      Id = td.Id,
                                      CreatedAt = td.CreatedAt,
                                      IsComlete = td.IsComlete,
                                      UserId = td.UserId,
                                      Name = td.Name
                                  }).ToList();
                u.Posts = posts.Where(post => post.UserId == u.Id)
                                  .Select(x => new Post
                                  {
                                      Id = x.Id,
                                      Body = x.Body,
                                      createdAt = x.createdAt,
                                      Likes = x.Likes,
                                      Title = x.Title,
                                      UserId = x.UserId,
                                      Comments = comments.Where(comment => comment.PostId == x.Id)
                                      .Select(y => new Comment
                                      {
                                          Id = y.Id,
                                          Body = y.Body,
                                          UserId = y.UserId,
                                          PostId = y.PostId,
                                          CreatedAt = y.CreatedAt,
                                          Likes = y.Likes
                                      }).ToList()
                                  }).ToList();


            }
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public List<Post> GetPosts()
        {
            return posts;
        }

        public List<Todo> GetTodos()
        {
            return todos;
        }

        public User GetUserById(int id)
        {
            return users.Where(u => u.Id == id).FirstOrDefault();
        }

        public Todo GetTodoById(int id)
        {
            return todos.Where(t => t.Id == id).FirstOrDefault();
        }

        public Post GetPostById(int id)
        {
            return posts.Where(p => p.Id == id).FirstOrDefault();
        }

        public int GetPostsCount(int id)
        {
            return posts.Where(p => p.UserId == id).Count();
        }

        public IEnumerable<Comment> GetPostComentsLessThenFiFtyLength(int userId)
        {
                return users.Where(u => u.Id == userId).SelectMany(u => u.Posts
                    .SelectMany(p => p.Comments).Where(c => c.Body.Length < 50)).ToList();
        }


        public IDictionary<int, string> GetDoneTodos(int userId)
        {
            var user = users.Where(u => u.Id == userId).FirstOrDefault();
            var doneTodos = user.Todos
                    .Where(td => td.IsComlete == true)
                    .Select(res => new { res.Id, res.Name })
                    .ToDictionary(t => t.Id, t => t.Name);

            return doneTodos;
        }

        public IEnumerable<User> GetSortedUserAndToDos()
        {
            var res = users
            .OrderBy(user => user.Name)
            .Select(user => new User
            {
                Id = user.Id,
                Todos = user.Todos.Select(x => x).OrderByDescending(todo => todo.Name).ToList(),
                Name = user.Name,
                Avatar = user.Avatar,
                CreatedAt = user.CreatedAt,
                Email = user.Email
            }).ToList();
            return res;
        }

        public PostResponse GetPostResponse(int postId)
        {
            var post = users.SelectMany(u => u.Posts)
                .Where(p => p.Id == postId).FirstOrDefault();

            var resp = new PostResponse
            {
                TheBiggestComment = post.Comments.OrderByDescending(c => c.Body.Length)
                   .Select(x => x).FirstOrDefault(),
                TheMostLikedComment = post.Comments
                   .OrderByDescending(c => c.Likes)
                   .Select(x => x).FirstOrDefault(),
                QuantityOfNeededComment = post.Comments.Count(c => c.Likes == 0 || c.Body.Length <= 80)

            };
            return resp;
        }

        public UserResponse GetUserResponse(int userId)
        {
            var user = users.Where(u => u.Id == userId).FirstOrDefault();

            var resp = new UserResponse
            {
                QuantityOfNotDoneTodos = user.Todos.Where(todo => todo.IsComlete == false).Count(),
                TheLatestPost = user.Posts.OrderByDescending(x => x.createdAt).FirstOrDefault(),
                QuantityComentsAtLastPost = user.Posts.OrderByDescending(x => x.createdAt)
                    .FirstOrDefault()?.Comments?.Count() ?? 0,
                MostPopularPostWithComments = user.Posts
                    .OrderByDescending(x => x.Comments).FirstOrDefault(x => x.Body.Length > 80),
                MostPopularPostWithLikes = user.Posts
                    .OrderByDescending(x => x.Likes).FirstOrDefault()
            };

            return resp;
        }

    }
}
