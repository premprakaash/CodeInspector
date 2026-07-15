import DashboardIcon from "@mui/icons-material/Dashboard";
import FolderIcon from "@mui/icons-material/Folder";
import SearchIcon from "@mui/icons-material/Search";
import DescriptionIcon from "@mui/icons-material/Description";
import SettingsIcon from "@mui/icons-material/Settings";

import {
    Drawer,
    List,
    ListItemButton,
    ListItemIcon,
    ListItemText
} from "@mui/material";

import { useNavigate } from "react-router-dom";

const drawerWidth = 250;

export default function Sidebar() {

    const navigate = useNavigate();

    return (

        <Drawer
            variant="permanent"
            sx={{
                width: drawerWidth,
                flexShrink: 0,
                '& .MuiDrawer-paper': {
                    width: drawerWidth,
                    boxSizing: 'border-box',
                },
            }}
        >

            <List>

                <ListItemButton onClick={() => navigate("/dashboard")}>
                    <ListItemIcon>
                        <DashboardIcon />
                    </ListItemIcon>

                    <ListItemText primary="Dashboard" />
                </ListItemButton>

                <ListItemButton onClick={() => navigate("/projects")}>
                    <ListItemIcon>
                        <FolderIcon />
                    </ListItemIcon>

                    <ListItemText primary="Projects" />
                </ListItemButton>

                <ListItemButton onClick={() => navigate("/scan")}>
                    <ListItemIcon>
                        <SearchIcon />
                    </ListItemIcon>

                    <ListItemText primary="Scan" />
                </ListItemButton>

                <ListItemButton onClick={() => navigate("/reports")}>
                    <ListItemIcon>
                        <DescriptionIcon />
                    </ListItemIcon>

                    <ListItemText primary="Reports" />
                </ListItemButton>

                <ListItemButton onClick={() => navigate("/settings")}>
                    <ListItemIcon>
                        <SettingsIcon />
                    </ListItemIcon>

                    <ListItemText primary="Settings" />
                </ListItemButton>

            </List>

        </Drawer>

    );

}