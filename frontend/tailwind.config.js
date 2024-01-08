/** @type {import('tailwindcss').Config} */
export default {
  darkMode: 'class',
  content: ['./index.html', './src/**/*.{vue,js,ts,jsx,tsx}','formkit.theme.ts'],
  theme: {
    extend: {
      colors: {
        backgroundDark: {
          default: 'var(--vt-c-black)',
          soft: 'var(--vt-c-black-soft)',
          mute: 'var(--vt-c-black-mute)'
        },
        borderDark: {
          default: 'var(--vt-c-divider-dark-2)',
          hover: 'var(--vt-c-divider-dark-1)'
        },
        headingDark: 'var(--vt-c-text-dark-1)',
        textDark: 'var(--vt-c-text-dark-2)',

        backgroundLight: {
          default: 'var(--vt-c-white)',
          soft: 'var(--vt-c-white-soft)',
          mute: 'var(--vt-c-white-mute)'
        },
        borderLight: {
          default: 'var(--vt-c-divider-light-2)',
          hover: 'var(--vt-c-divider-light-1)'
        },
        headingLight: 'var(--vt-c-text-light-1)',
        textLight: 'var(--vt-c-text-light-2)'
      }
    }
  },
  plugins: []
}
