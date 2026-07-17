import { defineConfig } from "vite"
import react, { reactCompilerPreset } from "@vitejs/plugin-react"
import babel from "@rolldown/plugin-babel"
import tailwindcss from "@tailwindcss/vite"
import path from "path"

export default defineConfig({
  plugins: [
    react(),
    babel({ presets: [reactCompilerPreset()] }),
    tailwindcss(),
  ],
  server: {
    host: "0.0.0.0",
    port: 5173,
    allowedHosts: ["localhost", "127.1.0.0"],
  },
  resolve: {
    alias: {
      "@components": path.resolve(__dirname, "./src/components"),
      "@types": path.resolve(__dirname, "./src/types"),
      "@lib": path.resolve(__dirname, "./src/lib"),
      "@utils": path.resolve(__dirname, "./src/utils"),
      "@features": path.resolve(__dirname, "./src/features"),
    },
  },
  build: {
    chunkSizeWarningLimit: 600,
    rolldownOptions: {
      output: {
        codeSplitting: true,
        manualChunks(id) {
          if (id.includes("node_modules")) {
            if (id.includes("react") || id.includes("react-dom")) {
              return "react-vendor"
            }
            return "vendor"
          }
        },
      },
    },
  },
})
