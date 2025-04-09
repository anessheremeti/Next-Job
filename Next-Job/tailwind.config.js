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
        nunito:['Nunito']
      },
      
    },
  },
  plugins: [],
}



