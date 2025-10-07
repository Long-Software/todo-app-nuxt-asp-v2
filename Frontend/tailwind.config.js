/** @type {import('tailwindcss').Config} */
module.exports = {
  darkMode: "class",
  content: [
    // "./**/*.{js,ts,jsx,tsx,vue}",
    "./components/**/*.{vue,js,ts}",
    // "./layouts/**/*.{vue,js,ts}",
    "./pages/**/*.{vue,js,ts}",
    // "./plugins/**/*.{js,ts}",
    "./nuxt.config.{js,ts}",
    "./app.vue",
  ],
  theme: {
    extend: {},
  },
  plugins: [],
};
