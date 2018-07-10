using DataStructuresAndLINQ;
using DataStructuresAndLINQ.DataStructures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SocialNetworkMVC.Services
{
    public class DataService
    {
        private static List<User> users;
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

            foreach(User u in users)
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
    }
}
