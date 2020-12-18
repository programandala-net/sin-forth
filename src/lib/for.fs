\ lib/for.fs

\ This file is part of Sin Forth.

\ This file adds `for` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012181748.
\ See change log at the end of the file.

\ ==============================================================

require to-r.fs \ `>r`

get-order get-current

compiler-definitions

: for \ Compilation: ( -- dest )
      \ Run-time:    ( u -- )
  >r_dea call, <mark ;

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-16: Start. Copy the code from Solo Forth 0.14.0-pre.124.
\
\ 2020-12-18: Improve documentation.
