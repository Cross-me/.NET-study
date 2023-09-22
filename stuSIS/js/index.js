var app = new Vue({
	el: '#app',
	data: {
		pcn: false,
		icon: 'icon',
		search: false,
		screenWidth: '',
		showPcn: true,
		showYdn: false
	},
	methods: {
		icoN() {
			if (this.pcn === false) {
				this.pcn = !this.pcn
				this.icon = 'hide'
			}else{
				this.pcn = !this.pcn
				this.icon = 'icon'
			}
		},
		header() {
		    this.mousewheel = window.event.wheelDelta
			if (this.mousewheel > 0) {
				this.$refs.head.style.top = "0"
			}
			else if (this.mousewheel < 0) {
				this.$refs.head.style.top = "-100px"
			}
		},
		handleScroll() {
			let scrolltop = document.documentElement.scrolltop || document.body.scrollTop;
			scrolltop > 30 ? (this.gotop = true) : (this.gotop = false);
		},
		toTop() {
			let top = document.documentElement.scrollTop || document.body.scrollTop;
			const timeTop = setInterval(() => {
				document.body.scrollTop = document.documentElement.scrollTop = top -= 50;
				if (top <= 0) {
				clearInterval(timeTop);
				}
			}, 10);
			this.$refs.head.style.top = "0"
		},
		searchPlus() {
			this.search = !this.search
		},
		ydmenu() {
			if (this.screenWidth <= 850) {
				this.$refs.ydN.style.left = "0"
			}
		},
		closeYdn() {
			if (this.screenWidth <= 850) {
				this.$refs.ydN.style.left = "-250px"
			}
		}
	},
	mounted() {
	    window.addEventListener('mousewheel', this.header)
		window.addEventListener("scroll", this.handleScroll)
		this.screenWidth = document.body.clientWidth
		window.onresize = () => {
			return (() => {
				this.screenWidth = document.body.clientWidth;
				this.screenHeight = document.body.clientHeight;
			})()
		}
	},
	watch: {
		screenWidth(val) {
			if (val <= 850) {
				this.showPcn = false
				this.showYdn = true
				this.search = false
			} else {
				this.showPcn = true
				this.showYdn = false
			}
		}
	}
})