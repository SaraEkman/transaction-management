const { defineConfig } = require('cypress')

module.exports = defineConfig({
  env: {
    apiUrl: 'https://localhost:7207',
  },
  e2e: {
    baseUrl: 'http://127.0.0.1:4200',
    setupNodeEvents(on, config) {},
    supportFile: false,
  },
})
