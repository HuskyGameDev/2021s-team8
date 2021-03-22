using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask; //layer that will obscure the FOV
    [SerializeField] private float changeAngle = 0f; //allows for the angle to be changed
    [SerializeField] private float fov = 45f; //how wide the enemy's FOV is
    [SerializeField] private float viewDistance = 1f; //determines how far the fov goes
    private Mesh mesh; //mesh reference
    private Vector3 origin; //origin of the vision cone
    private float angle; //the angle that the furthest counterclockwise point of the vision cone is facing

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh; //sets the mesh filter to be the mesh created by the script
        GetComponent<MeshCollider>().sharedMesh = mesh; //ensures that the mesh collider has the same mesh as the vision cone
        origin = Vector3.zero;
        fov = 45f;
    }

    private void Update()
    {
        int rayCount = 20; //number of raycasts used to create the view cone
        float angleIncrease = fov / rayCount; //determines the difference in the angle between the the current ray and the next ray
        angle = angle + changeAngle; //sets the angle to be facing straight left by default

        Vector3[] vertices = new Vector3[rayCount + 1 + 1]; //vector3 array that contains the vertices of the FOV mesh
        Vector2[] uv = new Vector2[vertices.Length]; //vector2 arrray that contains the uv map locations for mesh
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, getVectorFromAngle(angle), viewDistance, layerMask); //sends out a raycast from the origin "viewDistance" distance which collides with anything on the proper layerMask

            if (raycastHit2D.collider == null) //if the raycast hits something, then the new vertex will be put at that point, otherwise, the vertext goes to the max distance
            {
                vertex = origin + getVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                vertex = raycastHit2D.point;
            }
            vertices[vertexIndex] = vertex;

            if (i > 0) //creates the triangle for the mesh
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }



        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    /* gets a vector from a given angle
     * 
     * parameter angle: angle to get the vector from
     * return: Vector3 equivelent to the angle given
     */
    public static Vector3 getVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    /* sets the origin of the view cone
     * 
     * parameter origin: Vector3 value of the origin
     */
    public void setOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    /* sets the angle to the given direction
     * 
     * parameter direction: the direction of the new angle
     */
    public void setDirection(float direction)
    {
        angle = direction;
    }

    /* gets the FOV of the FOV
     * 
     * return: float value of FOV
     */
     public float getFOV()
    {
        return fov;
    }
}
