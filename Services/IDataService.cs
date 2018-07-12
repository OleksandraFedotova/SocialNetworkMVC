using SocialNetworkMVC.Models;
using System.Collections.Generic;

namespace SocialNetworkMVC.Services
{
    public interface IDataService
    {
        List<User> GetUsers();

        List<Post> GetPosts();

        List<Todo> GetTodos();

        User GetUserById(int id);

        Todo GetTodoById(int id);

        Post GetPostById(int id);

        int GetPostsCount(int id);

        IEnumerable<Comment> GetPostComentsLessThenFiFtyLength(int userId);

        UserResponse GetUserResponse(int userId);

        PostResponse GetPostResponse(int postId);

        IEnumerable<User> GetSortedUserAndToDos();

        IDictionary<int, string> GetDoneTodos(int userId);


    }
}
