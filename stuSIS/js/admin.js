var app = new Vue({
	el: '#all',
	data:{
		
	},
	methods:{
		tongzhi() {
            this.$refs.tongzhi.style.display = 'block';
			this.$refs.wenzhang.style.display = 'none';
		},
		wenzhang() {
			this.$refs.tongzhi.style.display = 'none';
            this.$refs.wenzhang.style.display = 'block';
		}
	}
	
})