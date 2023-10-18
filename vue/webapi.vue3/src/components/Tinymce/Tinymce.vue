<!-- <template>
    <div>
        <Editor :id="tinymceId" :init="init" :disabled="disabled" v-model="myValue"></Editor>
    </div>
</template>
 
<script lang="ts">
//引入tinymce-vue
import Editor from '@tinymce/tinymce-vue'
//公共的图片前缀
//import Global from "./Global";
export default {
    components: { Editor },
    props: {
        //编号
        id: {
            type: String
        },
        //内容
        value: {
            type: String,
            default: ''
        },
        //是否禁用
        disabled: {
            type: Boolean,
            default: false
        },
        //插件
        plugins: {
            type: [String, Array],
            default: 'preview searchreplace autolink directionality visualblocks visualchars fullscreen image link media code codesample table charmap pagebreak nonbreaking anchor insertdatetime advlist lists wordcount help emoticons autosave autoresize formatpainter',
        },
        //工具栏
        toolbar: {
            type: [String, Array],
            default: 'code undo redo restoredraft | fullscreen | cut copy paste pastetext | forecolor backcolor bold italic underline strikethrough link anchor | alignleft aligncenter alignright alignjustify outdent indent | \
    styleselect formatselect fontselect fontsizeselect | bullist numlist | blockquote subscript superscript removeformat | \
    table image media charmap emoticons hr pagebreak insertdatetime print preview | bdmap indent2em lineheight formatpainter axupimgs',
        }
    },
    data() {
        let that = this;
        return {
            tinymceId: this.id || 'vue-tinymce' + Date.parse((new Date()).toString()),
            myValue: this.value,
            init: {
                //汉化,路径是自定义的
                language_url: './public/resource/tinymce/langszh-Hans.js',
                language: 'zh_CN',
                //皮肤
                skin: 'oxide',
                //插件
                plugins: this.plugins,
                //工具栏
                toolbar: this.toolbar,
                //高度
                height: 500,
                //图片上传
                images_upload_handler: function (blobInfo:any, success:any, failure:any) {
                    debugger
                    //文件上传的formData传递
                    // let formData = new FormData();
                    // formData.append('file', blobInfo.blob(), blobInfo.filename());
                    // //上传的api,和后端配合，返回的是图片的地址，然后加上公共的图片前缀
                    // that.$api.system.uploadImage(formData).then((res:any)=> {
                    //     var url = "tt"//Global.baseUrlImg + res;
                    //     console.log(url)
                    //     success(url)
                    // }).catch((ex: any) => {
                    //     failure('图片上传失败' + ex)
                    // });
                }
            }
        }
    },
    methods: {

    },
    watch: {
        //监听内容变化
        value(newValue:string) {
            this.myValue = newValue
        },
        myValue(newValue:string) {
            this.$emit('input', newValue)
        }
    }
}
</script>
<style>
.tox-notifications-container {
    display: none;
}

/*在页面正常使用时不用加这个样式，在弹窗使用时，要加这个样式，因为使用弹窗，z-index层数比较低，工具栏的一些工具不能使用，要将z-index层数提高。*/
.tox.tox-silver-sink.tox-tinymce-aux {
    z-index: 2100 !important;
}
</style> -->