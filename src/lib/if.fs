\ lib/if.fs

\ This file is part of Sin Forth.

\ This file adds `if` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012262229.
\ See change log at the end of the file.

\ ==============================================================

require zero-branch.fs  \ `0branch`
require forward-mark.fs \ `>mark`

get-order get-current

compiler-definitions

: if \ Compilation: ( -- orig )
     \ Run-time:    ( f -- )
  compiler{ 0branch >mark } ;

  \ doc{
  \
  \ if
  \   Compilation: ( C: -- orig )
  \   Run-time:    ( f -- )

  \
  \ Compilation: Compile a conditional `0branch` and put the
  \ location _orig_ of its unresolved destination on the
  \ control-flow stack, to be resolved by `else` or `then`.
  \
  \ Run-time: If _f_ is zero, continue execution at the location
  \ specified by the resolution of _orig_.
  \
  \ // XXX TODO
  \ // See also: `again`, `until`, `ahead`, `0if`, `-if`, `+if`, `andif`, `orif`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.
\
\ 2020-12-12: Finish and document.
