jQuery.fn.extend({
    stepProgressBar: function (currentStep) {
        currentStep = currentStep || this.currentStep() || 1;
        let childs = this
            .addClass("step-progress-bar")
            .find("li")
            .removeClass("step-past step-present step-future");

        childs.find(".content-stick").removeClass("step-past step-future");

        let size = childs.length < 1 ? 100 : 100 / childs.length;
        childs.css("width", size + "%");

        for (let i = 0; i < childs.length; i++) {
            let child = $(childs[i]);
            if (child.find("span.content-wrapper").length === 0) {
                child.wrapInner("<span class='content-wrapper'></span>");
                if (i > 0) child.append("<span class='content-stick'></span>");
                child.prepend("<span class='content-bullet'>" + (i + 1) + "</span>");
            }
            let stepName = i < currentStep - 1 ? "step-past"
                : i === currentStep - 1 ? "step-present"
                    : "step-future";
            child.addClass(stepName);
            if (i > 0) {
                let stickName = stepName === "step-present" ? "step-past" : stepName;
                child.find(".content-stick").addClass(stickName);
            }
            child.css("z-index", childs.length - i);
            child.find(":before").css("z-index", childs.length - i + 2);
        }
        return this;
    },

    currentStep: function () {
        var childs = this.find("li");
        for (let i = 0; i < childs.length; i++) {
            if ($(childs[i]).is(".step-present")) return i + 1;
        }
        return 1;
    },
});