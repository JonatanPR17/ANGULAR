/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      colors: {
        admin:{
          '1': '#1E3A8A',
          '2': '#F9FAFB',
          '3': '#F9FAFB',
          '4': '#D1D5DB',
          '5': '#F0FDF4',
          '6': '#FEF2F2',
          '7': '#3B82F6',
          '8': '#E5E7EB',
          '9': '#10B981',
          '10': '#F43F66',
          '11': '#9CA3AF',
          '12': '#4B5563',
          '13': '#A2A9B4',
          '14': '#CFE2E0',
        },
        dashboard: {
          '1': '#1f2b6c',
          '2': '#159be7',
          '3': '#bbcef3',
          '4': '#f7f9f9',
          '5': '#212124',
        },
        adm : {
          'primary': '#2D60FF',
          'secundary-letter': '#b1b1b1',
          'main-letter': '#343C6A',
          'letter': '#718ebf',
          'background': '#f5f7fa',
          'alert-1': '#FE5C73',
          'alert-2': '#FEAA09',
          'alert-3': '#ff82ac',
          'alert-4': '#dcfaf8',
          'alert-5': '#16dbcc',
          'combine-1': '#123288',
          'combine-2': '#295EEC',
          'border': '#e6eff5',
          'nav': '#F5F6FA',
        },
      },
      padding:{
        'global':'13.7%'
      },
      margin:{
        'global':'13.7%'
      }
    },
    fontFamily:{
      inter : ['Inter','sans-serif'],
      cormorant_Garamond : ['Cormorant Garamond','sans-serif'],
    },
  },
  plugins: [],
}

