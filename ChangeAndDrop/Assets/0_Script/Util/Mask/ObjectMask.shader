
// 오브젝트 마스크를 위해 외부 코드를 사용하였습니다.
// https://guks-blog.tistory.com/entry/Unity-%EB%A7%88%EC%8A%A4%ED%81%AC-%EC%98%A4%EB%B8%8C%EC%A0%9D%ED%8A%B8-%EB%A7%8C%EB%93%A4%EA%B8%B0%EC%98%A4%EB%B8%8C%EC%A0%9D%ED%8A%B8-%EC%88%A8%EA%B8%B0%EA%B8%B0


Shader "Custom/ObjectMask"
{
    SubShader
    {
        Tags { "Queue"="Geometry+10" }
        
        ColorMask 0
        ZWrite On

        Pass {}
    }
}
