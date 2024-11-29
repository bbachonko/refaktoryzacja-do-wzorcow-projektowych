from typing import Any, List, Union


class TreeNode:
    def __init__(self, data: Any):
        """Defines a data node.
        
        Since each node is described by its data containing and children 
        two fields may be used.
        """
        self.data = data
        self._children: List['TreeNode'] = []

    def add_child(
        self, 
        child_node: Union['TreeNode', List['TreeNode']]
    ):
        """
        Adds a single child or a list of children to the current node.

        Case when multiple childs are added and single child are considered.
        """
        if isinstance(child_node, list):
            for child in child_node:
                if isinstance(child, TreeNode):
                    self._children.append(child)
                else:
                    raise TypeError(
                        "All children must be TreeNode instances."
                    )
        elif isinstance(child_node, TreeNode):
            self._children.append(child_node)
        else:
            raise TypeError(
                "child_node must be a TreeNode instance or a list of TreeNode instances."
            )

    def __str__(self) -> str:
        """
        Returns a string representation of the tree with indentation.

        :return: A string representing the tree structure.
        """
        lines = []
        self._build_str(lines, level=0)
        return "\n".join(lines)

    def _build_str(
        self, 
        lines: List[str], 
        level: int
    ):
        """
        Helper method to build the string representation of the tree.

        :param lines: A list to accumulate the lines of the string.
        :param level: The current depth level in the tree for indentation.
        """
        indent = "--" * level * 2
        lines.append(f"{indent}{self.data}")
        for child in self._children:
            child._build_str(lines, level + 1)

def main():
    appetizers = TreeNode("Appetizers")
    main_courses = TreeNode("Main Courses")
    desserts = TreeNode("Desserts")
    beverages = TreeNode("Beverages")

    veg_appetizers = TreeNode("Vegetarian Appetizers")
    non_veg_appetizers = TreeNode("Non-Vegetarian Appetizers")

    spring_rolls = TreeNode("Spring Rolls")
    stuffed_mushrooms = TreeNode("Stuffed Mushrooms")

    chicken_wings = TreeNode("Chicken Wings")
    calamari = TreeNode("Calamari")

    veg_appetizers.add_child([spring_rolls, stuffed_mushrooms])
    non_veg_appetizers.add_child([chicken_wings, calamari])

    appetizers.add_child([veg_appetizers, non_veg_appetizers])

    classic = TreeNode("Polskie Zarlo")
    seafood = TreeNode("Seafood")

    # Creating menu items for Pasta
    schabowy = TreeNode("Kotlet Schabowy")
    pierogies = TreeNode("5 piergies")

    # Creating menu items for Seafood
    grilled_salmon = TreeNode("Grilled Salmon")
    shrimp_scampi = TreeNode("Shrimp Scampi")

    # Adding menu items to subcategories
    classic.add_child([schabowy, pierogies])
    seafood.add_child([grilled_salmon, shrimp_scampi])

    # Adding subcategories to Main Courses
    main_courses.add_child([classic, seafood])

    # Creating subcategories for Desserts
    cakes = TreeNode("Cakes")
    ice_cream = TreeNode("Ice Cream")

    # Creating menu items for Cakes
    chocolate_cake = TreeNode("Chocolate Cake")
    cheesecake = TreeNode("Cheesecake")

    # Creating menu items for Ice Cream
    vanilla = TreeNode("Vanilla Ice Cream")
    chocolate = TreeNode("Chocolate Ice Cream")

    # Adding menu items to subcategories
    cakes.add_child([chocolate_cake, cheesecake])
    ice_cream.add_child([vanilla, chocolate])

    # Adding subcategories to Desserts
    desserts.add_child([cakes, ice_cream])

    # Creating subcategories for Beverages
    hot_beverages = TreeNode("Hot Beverages")
    cold_beverages = TreeNode("Cold Beverages")

    # Creating menu items for Hot Beverages
    coffee = TreeNode("Coffee")
    tea = TreeNode("Tea")

    # Creating menu items for Cold Beverages
    soda = TreeNode("Soda")
    lemonade = TreeNode("Lemonade")

    # Adding menu items to subcategories
    hot_beverages.add_child([coffee, tea])
    cold_beverages.add_child([soda, lemonade])

    # Adding subcategories to Beverages
    beverages.add_child([hot_beverages, cold_beverages])

    # Creating the root of the menu
    restaurant_menu = TreeNode("Restaurant Menu")
    restaurant_menu.add_child([appetizers, main_courses, desserts, beverages])

    # Printing the menu
    print("Restaurant Menu Structure:")
    print(restaurant_menu)

if __name__ == "__main__":
    main()

