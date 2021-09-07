<template>
    <h3>{{setting.unBooking[detail-1].title}}</h3>
    <p>{{setting.unBooking[detail-1].detail}}</p>
</template>

<style lang="scss" scoped>
h3{
    font-size: 2rem;
    font-weight: 700;
    margin: 1rem 2rem;
}
p{
    margin: 1rem 2rem;
    line-height: 1.8rem;
}
@media screen and (min-width: 768px){
    h3{
        margin: 1rem 0;
        font-size: 1.3rem;
    }
    p{
        margin: 1rem 0;
    }
}
</style>

<script>
export default {
    props:["detail","setting"]
}
</script>