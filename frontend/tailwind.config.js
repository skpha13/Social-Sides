/** @type {import('tailwindcss').Config} */
export default {
  darkMode: 'class',
  content: ['./index.html', './src/**/*.{vue,js,ts,jsx,tsx}'],
  theme: {
    extend: {
      colors: {
        // TODO: define colors
        background: {
          default: "var(--color-background)",
          soft: "var(--color-background-soft)",
          mute: "var(--color-background-mute)"
        },
        border: {
          default: "var(--color-border)",
          hover: "var(--color-border-hover)"
        },
        heading: "var(--color-heading)",
        text: "var(--color-text)",
      }
    },
  },
  variants: {
    extend: {
      // backgroundColor: ['dark'], // Add dark mode variant for background color
      // borderColor: ['dark'], // Add dark mode variant for border color
      // textColor: ['dark'], // Add dark mode variant for text color
      // Add more variants as needed
    },
  },
  plugins: [],
}

