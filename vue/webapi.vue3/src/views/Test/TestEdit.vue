<template>
    <div>
        <TinymceEditor :value="content" @input="newContent"></TinymceEditor>
    </div>
</template>
  
<script lang="ts">
import TinymceEditor from "../../components/Tinymce/Tinymce.vue"
export default {
    components: {
        TinymceEditor
    },
    data() {
        return {
            content: ""
        }
    },
    methods: {
        // 获取富文本的内容
        newContent(val: string) {
            this.content = val; // 直接更新 content 属性
        }
    }
}
</script>