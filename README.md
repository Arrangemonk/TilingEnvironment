# TilingEnvironment
Tiling 3d Worlds without duplicating entities

![Demo](Demo/Demo.gif)

this is a Demo To explain how To achieve a seemingly infinite tiling environment.

step one only shows unrestricted movement -> the player could leave the playfield on its edges (usually this results in falling endlessly)

step 2 repeats the playerposition. over the playfield -> the player can no longer leave the playfield, but close to the edge "the void" can be seen

set 3 splits the playfield in 4 tiles, and swaps their position around the player position, so that there is no visibble gaps in the playfield 

this solution works only under the assumption , that the draw distance is smaller than a quater of the playfield.

for npcs/enemies the coordinates for distance calculation need to be taken into account (otherwise close to the border mobs seemingly randomly couldnt find the player)


