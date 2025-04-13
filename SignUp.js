
import React from "react";

const SignUp = () => {
  return (
    <div className="min-h-screen flex items-center justify-center bg-white px-4">
      <div className="max-w-4xl w-full grid grid-cols-1 md:grid-cols-2 shadow-xl rounded-xl overflow-hidden">
        <div className="hidden md:block">
          <img
            src="https://source.unsplash.com/random/600x800?sunset"
            alt="Signup"
            className="h-full w-full object-cover"
          />
        </div>
        <div className="p-8 md:p-10">
          <h2 className="text-3xl font-bold text-gray-800 mb-6">Sign up</h2>
          <form className="space-y-4">
            <input type="text" placeholder="Full Name" className="w-full px-4 py-2 border rounded-md" />
            <input type="email" placeholder="Email" className="w-full px-4 py-2 border rounded-md" />
            <input type="password" placeholder="Password" className="w-full px-4 py-2 border rounded-md" />
            <button className="w-full bg-purple-600 text-white py-2 rounded-md hover:bg-purple-700">Sign up</button>
          </form>
          <p className="mt-4 text-sm text-gray-500 text-center">
            Already have an account? <a href="/login" className="text-purple-600">Login</a>
          </p>
        </div>
      </div>
    </div>
  );
};

export default SignUp;
