
import React from "react";

const BlogList = () => {
  const blogs = [
    {
      id: 1,
      title: "Remote Work Tips",
      description: "How to manage remote teams successfully.",
      image: "https://source.unsplash.com/random/400x300?office",
    },
    {
      id: 2,
      title: "Productivity Hacks",
      description: "Maximize your efficiency at home.",
      image: "https://source.unsplash.com/random/400x300?laptop",
    },
  ];

  return (
    <div className="min-h-screen bg-gray-50">
      <header className="bg-white shadow">
        <div className="max-w-7xl mx-auto py-6 px-4 flex justify-between items-center">
          <h1 className="text-2xl font-bold text-gray-800">Blogs</h1>
          <button className="bg-purple-600 text-white px-4 py-2 rounded-md hover:bg-purple-700">New Post</button>
        </div>
      </header>

      <main className="max-w-7xl mx-auto px-4 py-10">
        <div className="grid md:grid-cols-3 gap-6">
          {blogs.map((blog) => (
            <div key={blog.id} className="bg-white rounded-xl shadow-md overflow-hidden">
              <img src={blog.image} alt={blog.title} className="w-full h-48 object-cover" />
              <div className="p-4">
                <h2 className="text-xl font-semibold text-gray-800">{blog.title}</h2>
                <p className="text-sm text-gray-500 mt-1">{blog.description}</p>
              </div>
            </div>
          ))}
        </div>
      </main>
    </div>
  );
};

export default BlogList;
