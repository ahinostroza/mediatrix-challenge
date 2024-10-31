/** @type {import('tailwindcss').Config} */
export default {
  content: [
    './index.html',
    './src/**/*.{js,ts,jsx,tsx}'
  ],
  theme: {
    colors: {
      transparent: 'transparent',
      current: 'currentColor',
      primary: '#0d3048',
      secondary: '#d9480f',
      white: '#FFFFFF',
      gray: '#edf0f7;'
    },
    extend: {},
  },
  plugins: [],
}

