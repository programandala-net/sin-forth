\ lib/for.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T1006+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require backward-mark.fs \ `<mark`
require to-r.fs          \ `>r`

get-order get-current

compiler-definitions

: for \ Compilation: ( -- dest )
      \ Run-time:    ( u -- )
    compiler{ >r } <mark ;

  \ doc{
  \
  \ for
  \   Compilation: ( -- dest )
  \   Run-time:    ( u -- )

  \
  \ Start a ``for``..`step` loop, that will iterate _u+1_ times,
  \ starting with _u_ and ending with 0.
  \
  \ Compilation: left the destination address _dest_ of the beginning
  \ of the loop, to be resolved by `step`.
  \
  \ Run-time: Move the initial value of the index _u_ to the return
  \ stack. Inside the loop its current value can be retrieved with `r@`.
  \
  \ // XXX TODO // See also: `dfor`, `times`, `?do`, `executions`.
  \
  \ }doc

set-current set-order
