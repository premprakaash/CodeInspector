import {
    AppBar,
    Toolbar,
    Typography,
    IconButton,
    Avatar,
    Box,
    Badge
} from "@mui/material";

import NotificationsIcon from "@mui/icons-material/Notifications";

export default function Topbar() {

    return (

        <AppBar
            position="fixed"
            sx={{
                ml: "250px",
                width: "calc(100% - 250px)",
                background: "#1976d2"
            }}
        >

            <Toolbar>

                <Typography
                    variant="h6"
                    sx={{ flexGrow: 1 }}
                >
                    CodeInspector
                </Typography>

                <IconButton color="inherit">

                    <Badge badgeContent={5} color="error">

                        <NotificationsIcon />

                    </Badge>

                </IconButton>

                <Box sx={{ ml: 3 }}>

                    <Avatar>P</Avatar>

                </Box>

            </Toolbar>

        </AppBar>

    );
}