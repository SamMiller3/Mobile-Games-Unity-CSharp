//face car
        if (pause.paused == 0){
            Vector3 Carpos = Car.transform.position - transform.position;
         float angle = Mathf.Atan2(Carpos.y, Carpos.x) * Mathf.Rad2Deg - 90;
         Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 1000);
        transform.position += transform.up * Time.deltaTime * 0.4f;
        offsetx = transform.position.x;
        offsety = transform.position.y;