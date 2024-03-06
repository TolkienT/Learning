<template>
  <a-layout style="height: 100%">
    <a-layout-header class="header" v-if="$route.meta.showNavBar">
      <div class="logo" />
      <a-menu
        v-model:selectedKeys="selectedKeys1"
        theme="dark"
        mode="horizontal"
        :style="{ lineHeight: '64px' }"
      >
        <a-menu-item key="1"><router-link to="/dashboard">Home</router-link></a-menu-item>
        <a-menu-item key="2"><router-link to="/login">Login</router-link></a-menu-item>
        <a-menu-item key="3"><router-link to="/dashboard/sysParam">Login</router-link></a-menu-item>
      </a-menu>
    </a-layout-header>
    <a-layout>
      <router-view/>
    </a-layout>
  </a-layout>
  
  <!-- <nav>
    <router-link to="/">Home</router-link> |
    <router-link to="/about">About</router-link>
  </nav> -->

</template>

<script lang="ts">
import { UserOutlined, LaptopOutlined, NotificationOutlined } from '@ant-design/icons-vue';
import { defineComponent, ref } from 'vue';
export default defineComponent({
  components: {
    UserOutlined,
    LaptopOutlined,
    NotificationOutlined,
  },
  setup() {
    return {
      selectedKeys1: ref<string[]>(['1'])
    };
  },
});</script>

<style lang="scss">
body{
  margin: auto;
}
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin: auto;
  height: 100vh;
}

nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
