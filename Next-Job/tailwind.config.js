/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      fontFamily: {
        poppins: ['Poppins', 'sans-serif'],
        monument: ['Monument-Regular'],
        monumentBold: ['Monument-Ultrabold'],
        clashLight: ['ClashDisplay-Light'],
        clashDisplay: ['ClashDisplay-Regular'],
        nunito: ['Nunito']
      },
      colors: {
        lightBackground: '#F9F9F9',
        deepGreen: '#216F4C',
      }
    }
  },
  plugins: [],
}
