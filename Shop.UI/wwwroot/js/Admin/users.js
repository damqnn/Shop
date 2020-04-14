var app = new Vue({
    el: '#app',
    data: {
        
        username: ""
    },
    mounted() {
        
    },
    methods: {
        createUser() {
            this.loading = true;
            axios.post('/Admin/users', { username: this.username })
                .then(res => {
                    console.log(res);
                    
                })
                .catch(err => {
                    console.log(err);
                })
        },
      
    }
})