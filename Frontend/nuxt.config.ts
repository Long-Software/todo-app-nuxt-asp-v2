// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: "2025-07-15",
  devtools: { enabled: true },
  css: ["~/assets/css/main.css"],
  modules: ["@pinia/nuxt"],
  // vite: {
  //   plugins: [tailwindcss()],
  // },
  postcss: {
    plugins: {
      "@tailwindcss/postcss": {},
      autoprefixer: {},
    },
  },
  pinia: {
    storesDirs: ["./store/**"],
  },
});
