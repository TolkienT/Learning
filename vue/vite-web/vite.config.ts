import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import { resolve } from 'path'

import Components from 'unplugin-vue-components/vite'
import { ElementPlusResolver } from 'unplugin-vue-components/resolvers'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue(),
    Components({
      // allow auto load markdown components under `./src/components/`
      extensions: ['vue', 'md'],
      // allow auto import and register components used in markdown
      include: [/\.vue$/, /\.vue\?vue/, /\.md$/],
      resolvers: [
        ElementPlusResolver({
          importStyle: 'sass',
        }),
      ],
      dts: 'src/types/components.d.ts',
    }),
  ],
  //解决“vite use `--host` to expose”
  base: './',	//不加打包后白屏
  server: {             
    host: '0.0.0.0',	
    port: 8080,      
    open: true
  },
  resolve:{   
    //别名配置，引用src路径下的东西可以通过@如：import Layout from '@/layout/index.vue'
    alias:[   
      {
        find:'@',
        replacement:resolve(__dirname,'src') 
      }
    ]
  }
})
